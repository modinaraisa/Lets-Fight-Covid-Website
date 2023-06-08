using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LetsFightCovid.Startup))]
namespace LetsFightCovid
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
