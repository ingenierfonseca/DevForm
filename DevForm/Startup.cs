using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DevForm.Startup))]
namespace DevForm
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
