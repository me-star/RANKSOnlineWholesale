using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RANKSOnlineWholesale.Startup))]
namespace RANKSOnlineWholesale
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
