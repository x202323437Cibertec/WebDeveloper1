using System.Web.Http;

namespace Cibertec.WepAPI.App_Start
{
    public static class RouteConfig
    {
        public static void Register(HttpConfiguration pConfig)
        {
            pConfig.Routes.MapHttpRoute(
                name: "DefaultApi"
                ,routeTemplate: "api/{controller}/{id}"
                ,defaults: new { id = RouteParameter.Optional }
                );
        }
    }
}
