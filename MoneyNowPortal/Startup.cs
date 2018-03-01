using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MoneyNowPortal.Startup))]
namespace MoneyNowPortal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
