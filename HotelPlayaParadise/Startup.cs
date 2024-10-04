using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HotelPlayaParadise.Startup))]
namespace HotelPlayaParadise
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
