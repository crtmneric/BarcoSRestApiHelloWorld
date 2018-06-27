using System.Web.Http;
using Owin;

namespace BarcoSRestApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            WebApiConfig.Register(config);

            ConfigureAuth(app);
        }
    }
}