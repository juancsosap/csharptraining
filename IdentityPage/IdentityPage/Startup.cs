using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IdentityPage.Startup))]
namespace IdentityPage
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
