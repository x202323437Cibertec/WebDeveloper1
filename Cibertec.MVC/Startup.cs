using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;
using Microsoft.Owin.Security.Cookies;

[assembly: OwinStartup(typeof(Cibertec.MVC.Startup))]

namespace Cibertec.MVC
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie"
                ,LoginPath = new PathString("/Account/Login")
            });
            app.MapSignalR();
        }
    }
}
