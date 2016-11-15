using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NegoShoeTracker.Web.Startup))]
namespace NegoShoeTracker.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
