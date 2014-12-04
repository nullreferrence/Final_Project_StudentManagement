using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RegProbSolveing1.Startup))]
namespace RegProbSolveing1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
