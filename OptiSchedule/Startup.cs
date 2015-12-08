using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OptiSchedule.Startup))]
namespace OptiSchedule
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
