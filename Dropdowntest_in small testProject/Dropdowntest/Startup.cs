using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Dropdowntest.Startup))]
namespace Dropdowntest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
