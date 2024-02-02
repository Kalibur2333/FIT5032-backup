using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FolioProject.Startup))]
namespace FolioProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
