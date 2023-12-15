using Cibertec.WepAPI.App_Start;
using Microsoft.Owin;
using Owin;
using System.Web.Http;

[assembly: OwinStartup(typeof(Cibertec.WepAPI.Startup))]

namespace Cibertec.WepAPI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            RouteConfig.Register(config);
            app.UseWebApi(config);
        }
    }
}
