using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DepartmentUnique2.Startup))]
namespace DepartmentUnique2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
