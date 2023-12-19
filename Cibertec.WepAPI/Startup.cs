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
            log4net.Config.XmlConfigurator.Configure();
            var vLog = log4net.LogManager.GetLogger(typeof(Startup));
            vLog.Debug("Logger iniciado");

            var config = new HttpConfiguration();
            DIConfig.ConfigureInjector(config);
            TokenConfig.ConfigureOAuth(app, config);
            RouteConfig.Register(config);
            WebApiConfig.Configure(config);
            app.UseWebApi(config);
        }
    }
}
