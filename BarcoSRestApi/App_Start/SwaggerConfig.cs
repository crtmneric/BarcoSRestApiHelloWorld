using BarcoSRestApi;
using BarcoSRestApi.Provider;
using Swashbuckle.Application;
using System;
using System.Web.Http;
using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace BarcoSRestApi
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.DescribeAllEnumsAsStrings();
                        c.SingleApiVersion("v1", "BarcoSRestApi");                 
                        c.IncludeXmlComments(GetXmlCommentsPath());
                        c.OAuth2("oauth2")
                            .Description("OAuth2 Implicit Grant")
                            .Flow("implicit")
                            .AuthorizationUrl("")
                            .TokenUrl("")
                            .Scopes(scopes =>
                            {
                                scopes.Add("read", "Read access to protected resources");
                                scopes.Add("write", "Write access to protected resources");
                            });

                        c.OperationFilter<AssignOAuth2SecurityRequirements>();

                    })
                .EnableSwaggerUi(c =>
                    {
                       
                    });
        }

        private static string GetXmlCommentsPath()
        {
            return AppDomain.CurrentDomain.BaseDirectory + @"\bin\Swagger.XML";
        }
    }
}
