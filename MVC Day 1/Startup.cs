using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_Day_1.Startup))]
namespace MVC_Day_1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
