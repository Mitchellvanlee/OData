using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(POCOData.Startup))]

namespace POCOData
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
