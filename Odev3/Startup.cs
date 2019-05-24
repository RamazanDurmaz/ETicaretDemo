using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Odev3.Startup))]
namespace Odev3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
