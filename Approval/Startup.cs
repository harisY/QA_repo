using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Approval.Startup))]
namespace Approval
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
