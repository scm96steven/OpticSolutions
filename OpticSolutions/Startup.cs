using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OpticSolutions.Startup))]
namespace OpticSolutions
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
