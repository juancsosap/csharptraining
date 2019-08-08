using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GetStartedWeb.Startup))]
namespace GetStartedWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
