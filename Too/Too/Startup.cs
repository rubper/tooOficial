using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Too.Startup))]
namespace Too
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
