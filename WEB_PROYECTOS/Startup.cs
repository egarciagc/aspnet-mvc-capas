using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WEB_PROYECTOS.Startup))]
namespace WEB_PROYECTOS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
