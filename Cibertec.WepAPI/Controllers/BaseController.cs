using Cibertec.UnitOfWork;
using System.Web.Http;

namespace Cibertec.WepAPI.Controllers
{
    public class BaseController : ApiController
    {
        protected readonly IUnitOfWork _unit;

        public BaseController(IUnitOfWork pUnit)
        {
            _unit = pUnit;
        }
    }
}
