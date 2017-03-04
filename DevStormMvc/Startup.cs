using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DevStormMvc.Startup))]
namespace DevStormMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
