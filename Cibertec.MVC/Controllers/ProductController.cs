using Cibertec.Models;
using Cibertec.Repositories.Dapper.Northwind;
using Cibertec.UnitOfWork;
using log4net;
using System.Configuration;
using System.Web.Mvc;

namespace Cibertec.MVC.Controllers
{
    public class ProductController : BaseController
    {
        public ProductController(ILog pLog, IUnitOfWork pUnit) : base(pLog, pUnit) { }

        public ActionResult Index()
        {
            ViewBag.ModelName2 = typeof(Cibertec.Models.Products).Name;
            ViewBag.dato2 = "Listado";
            return View(_unit.Products.GetList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Products pProduct)
        {
            if (ModelState.IsValid)
            {
                int int0 = _unit.Products.Insert(pProduct);
                pProduct.ProductID = int0; // Si algun dia se usa aca el ID; es con el valor de retorno
                RedirectToAction("Index");
            }
            return View(pProduct);
        }

        public ActionResult Edit(int pId)
        {
            return View(_unit.Products.GetById(pId));
        }

        [HttpPost]
        public ActionResult Edit(Products pProduct)
        {
            if (ModelState.IsValid)
            {
                _unit.Products.Update(pProduct);
                RedirectToAction("Index");
            }
            return View(pProduct);
        }


        public ActionResult Delete(int pId)
        {
            return View(_unit.Products.GetById(pId));
        }

        [HttpPost]
        public ActionResult Delete(Products pProduct)
        {
            if (_unit.Products.Delete(pProduct)) { return RedirectToAction("Index"); }
            return View(pProduct);
        }

    }
}