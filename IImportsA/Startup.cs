using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IImportsA.Startup))]
namespace IImportsA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
