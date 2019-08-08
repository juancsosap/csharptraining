using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UAIWeb.Startup))]
namespace UAIWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
