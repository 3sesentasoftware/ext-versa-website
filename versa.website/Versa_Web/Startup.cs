using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Versa_Web.Startup))]
namespace Versa_Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
