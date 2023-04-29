using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcBooksApp.Startup))]
namespace MvcBooksApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
