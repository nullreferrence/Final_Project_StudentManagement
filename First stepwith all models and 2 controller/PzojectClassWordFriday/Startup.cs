using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PzojectClassWordFriday.Startup))]
namespace PzojectClassWordFriday
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
