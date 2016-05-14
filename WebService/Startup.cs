using Microsoft.Owin;
using Owin;
using WebService;

[assembly: OwinStartup(typeof(Startup))]

namespace WebService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
