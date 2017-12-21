using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(dhimancars.Startup))]
namespace dhimancars
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
