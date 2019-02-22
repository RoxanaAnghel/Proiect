using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Pet.Web.Startup))]
namespace Pet.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
