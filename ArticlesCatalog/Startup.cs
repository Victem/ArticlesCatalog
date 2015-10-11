using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ArticlesCatalog.Startup))]
namespace ArticlesCatalog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
