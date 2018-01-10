using System.Web.Http;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ODataPOC.Startup))]
namespace ODataPOC
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //            HttpConfiguration config = new HttpConfiguration();
            //            config.EnableSwagger();
            //            app.Use(config);
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}