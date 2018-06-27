using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using BarcoSRestApi.Models;
using BarcoSRestApi.Services;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;

namespace BarcoSRestApi.Provider
{
    public class OAuthAppProvider : OAuthAuthorizationServerProvider
    {
        private readonly BarcosEntities db = new BarcosEntities();

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            return Task.Factory.StartNew(() =>
            {
                var username = context.UserName;
                var password = context.Password;
                var userService = new UserService();
                var user = userService.GetUserByCredentials(username, password);
                if (user != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.auth_name),
                        new Claim("UserID", user.id.ToString())
                    };

                    var oAutIdentity = new ClaimsIdentity(claims, Startup.OAuthOptions.AuthenticationType);

                    context.Validated(new AuthenticationTicket(oAutIdentity, new AuthenticationProperties()));
                }
                else
                {
                    context.SetError("invalid_grant", "Error");
                }
            });
        }

        public override Task TokenEndpointResponse(OAuthTokenEndpointResponseContext context)
        {
            var accessToken = context.AccessToken;
            var newWarehouse = new Warehouse
            {
                name = accessToken,
                reg_date = DateTime.Parse(context.Properties.ExpiresUtc.ToString())
            };

            db.Warehouses.Add(newWarehouse);
            db.SaveChanges();
            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            if (context.ClientId == null) context.Validated();
            return Task.FromResult<object>(null);
        }
    }
}