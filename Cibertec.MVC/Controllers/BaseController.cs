using Cibertec.UnitOfWork;
using log4net;
using System.Web.Mvc;

namespace Cibertec.MVC.Controllers
{
    public class BaseController : Controller
    {
        public readonly ILog _log;
        public readonly IUnitOfWork _unit;

        public BaseController(ILog pLog, IUnitOfWork pUnit)
        {
            _log = pLog;
            _unit = pUnit;
        }

    }
}