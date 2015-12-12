using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EmploiASP.Startup))]
namespace EmploiASP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
