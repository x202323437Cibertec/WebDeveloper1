using Cibertec.Models;
using Cibertec.MVC.ActionFilters;
using Cibertec.Repositories.Dapper.Northwind;
using Cibertec.UnitOfWork;
using log4net;
using System.Collections.Generic;
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
                //RedirectToAction("Index");
                return RedirectToAction ("Index");
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
                //RedirectToAction("Index");
                return RedirectToAction("Index");
            }
            //return View(pCustomer);
            return PartialView("_Edit", pCustomer);
        }

        //public ActionResult Delete(string pId)
        //{
        //    return View(_unit.Customers.GetById(pId));
        //}
        public PartialViewResult Delete(string pId)
        {
            return PartialView("_Delete", _unit.Customers.GetById(pId));
        }

        [HttpPost]
        public ActionResult Delete(Customers pCustomer)
        {
            if (_unit.Customers.Delete(pCustomer)) { return RedirectToAction("Index"); }
            //return View(pCustomer);
            return PartialView("_Delete", pCustomer);
        }

        public ActionResult Details(string pId)
        {
            var customer = _unit.Customers.GetById(pId);
            //return PartialView("_DetalleCliente", customer);
            return View("DetalleCliente", customer);
        }

        [Route("Customer/List/{pPage:int}/{pRows:int}")]
        public PartialViewResult List(int pPage, int pRows)
        {
            if (pPage <= 0 || pRows <= 0)
            {
                return PartialView(new List<Customers>());
            }
            var iStartRecord = ((pPage - 1) * pRows) + 1;
            var iEndRecord = pPage * pRows;
            return PartialView("_List", _unit.Customers.PagedList(iStartRecord, iEndRecord));
        }

        [HttpGet]
        [Route("Customer/Count/{pRows:int}")]
        public int Count(int pRows)
        {
            var totalRecords = _unit.Customers.Count();
            return totalRecords % pRows != 0 ? (totalRecords / pRows) + 1 : totalRecords / pRows;
        }

    }
}