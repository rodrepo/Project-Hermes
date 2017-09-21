using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjectHermes.Web.Startup))]
namespace ProjectHermes.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
