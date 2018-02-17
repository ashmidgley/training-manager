using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LiftManager.Startup))]
namespace LiftManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
