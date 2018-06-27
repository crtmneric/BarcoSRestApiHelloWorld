using System.Web;
using System.Web.Http;
using BarcoSRestApi.Extensions;

namespace BarcoSRestApi
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            Logger.Setup();
        }
    }
}