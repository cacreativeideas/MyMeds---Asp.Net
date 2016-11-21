using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(WebLayer.Startup))]

namespace WebLayer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
