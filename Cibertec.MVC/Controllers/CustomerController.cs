using Cibertec.Models;
using Cibertec.MVC.ActionFilters;
using Cibertec.Repositories.Dapper.Northwind;
using Cibertec.UnitOfWork;
using log4net;
using System.Configuration;
using System.Web.Mvc;

namespace Cibertec.MVC.Controllers
{
    public class CustomerController : BaseController
    {
        public CustomerController(ILog pLog, IUnitOfWork pUnit) : base(pLog, pUnit) { }

        [RegistroActionFilter]
        public ActionResult Index()
        {
            ViewBag.ModelName = typeof(Cibertec.Models.Customers).Name;
            ViewBag.dato = "Listado";
            _log.Info("Ejecución del controlador Customer OK");
            return View(_unit.Customers.GetList());
        }

        //public ActionResult Create()
        //{
        //    return View();
        //}
        public PartialViewResult Create()
        {
            return PartialView("_Create", new Customers());
        }

        [HttpPost]
        public ActionResult Create(Customers pCustomer)
        {
            if (ModelState.IsValid)
            {
                _unit.Customers.Insert(pCustomer);
                RedirectToAction("Index");
            }
            //return View(pCustomer);
            return PartialView("_Create", pCustomer);
        }

        //public ActionResult Edit(string pId)
        //{
        //    return View(_unit.Customers.GetById(pId));
        //}
        public PartialViewResult Edit(string pId)
        {
            return PartialView("_Edit", _unit.Customers.GetById(pId));
        }

        [HttpPost]
        public ActionResult Edit(Customers pCustomer)
        {
            if (ModelState.IsValid)
            {
                _unit.Customers.Update(pCustomer);
                RedirectToAction("Index");
            }
            //return View(pCustomer);
            return PartialView("_Edit", pCustomer);
        }

        public ActionResult Delete(string pId)
        {
            return View(_unit.Customers.GetById(pId));
        }

        [HttpPost]
        public ActionResult Delete(Customers pCustomer)
        {
            if (_unit.Customers.Delete(pCustomer)) { return RedirectToAction("Index"); }
            return View(pCustomer);
        }

        public ActionResult Details(string pId)
        {
            var customer = _unit.Customers.GetById(pId);
            //return PartialView("_DetalleCliente", customer);
            return View("DetalleCliente", customer);

        }
    
    }
}