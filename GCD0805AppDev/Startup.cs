using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GCD0805AppDev.Startup))]
namespace GCD0805AppDev
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
