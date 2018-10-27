using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TrainingManager.Startup))]
namespace TrainingManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
