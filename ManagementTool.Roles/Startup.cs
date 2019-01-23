using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ManagementTool.Roles.Startup))]
namespace ManagementTool.Roles
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
