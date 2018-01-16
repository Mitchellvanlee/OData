using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(POCOData.Startup))]

namespace POCOData
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
