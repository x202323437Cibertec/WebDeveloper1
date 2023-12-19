using Cibertec.UnitOfWork;
using log4net;
using System.Web.Http;

namespace Cibertec.WepAPI.Controllers
{
    [Authorize]
    public class BaseController : ApiController
    {
        protected readonly IUnitOfWork _unit;
        protected readonly ILog _log;

        public BaseController(IUnitOfWork pUnit, ILog pLog)
        {
            _unit = pUnit;
            _log = pLog;
        }
    }
}
