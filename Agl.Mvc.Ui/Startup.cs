using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Agl.Mvc.Ui.Startup))]
namespace Agl.Mvc.Ui
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
