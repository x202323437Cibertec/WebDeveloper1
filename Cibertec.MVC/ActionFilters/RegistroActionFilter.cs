using log4net;
using System;
using System.Reflection;
using System.Web.Mvc;

namespace Cibertec.MVC.ActionFilters
{
    public class RegistroActionFilter: ActionFilterAttribute
    {
        protected static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var vMensaje = string.Format("Inicia la ejecución de: Controlador {0}, Acción {1}, Hora Inicio {2}", filterContext.Controller.ToString(), filterContext.ActionDescriptor.ActionName, DateTime.Now.ToString());
            _log.Debug(vMensaje);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var vMensaje = string.Format("Termina la ejecución de: Controlador {0}, Acción {1}, Hora Inicio {2}", filterContext.Controller.ToString(), filterContext.ActionDescriptor.ActionName, DateTime.Now.ToString());
            _log.Debug(vMensaje);
            RegistraMensaje("Después de ejecutar la acción", filterContext);
        }

        private void RegistraMensaje(string pMensaje, ControllerContext pContext)
        {
            string strMensaje = $"{pMensaje} en el controlador";
            pContext.Controller.ViewBag.MensajeLog = strMensaje;
        }
    }
}