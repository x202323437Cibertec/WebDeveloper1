using Cibertec.Models;
using Cibertec.UnitOfWork;
using System.Web.Http;

namespace Cibertec.WepAPI.Controllers
{
    [RoutePrefix("customer")]
    public class CustomerController : BaseController
    {
        public CustomerController(IUnitOfWork pUnit) : base(pUnit) { }

        [Route("")]
        [HttpPost]
        public IHttpActionResult Post(Customers pCustomer)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var vId = _unit.Customers.Insert(pCustomer);
            return Ok(new { rId = vId });
        }

        [Route("")]
        [HttpPut]
        public IHttpActionResult Put(Customers pCustomer)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var boResult = _unit.Customers.Update(pCustomer);
            if (boResult == false) return BadRequest("No se actualizó");
            return Ok(new { rActualizado = true });
        }

        [Route("{pId}")]
        [HttpGet]
        public IHttpActionResult Get(string pId)
        {
            if (string.IsNullOrEmpty(pId)) return BadRequest();
            return Ok(_unit.Customers.GetById(pId));
        }

        [Route("list")]
        [HttpGet]
        public IHttpActionResult GetList()
        {
            return Ok(_unit.Customers.GetList());
        }

    }
}