﻿using System.Linq;
using Microsoft.Owin;

namespace BarcoSRestApi.Extensions
{
    public static class OwinContextExtensions
    {
        public static string GetUserId(this IOwinContext ctx)
        {
            var result = "-1";
            var claim = ctx.Authentication.User.Claims.FirstOrDefault(c => c.Type == "UserID");
            if (claim != null) result = claim.Value;
            return result;
        }
    }
}