using Cibertec.Models;
using Cibertec.UnitOfWork;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cibertec.WepAPI.Controllers
{
    [RoutePrefix("product")]
    public class ProductController : BaseController
    {
        public ProductController(IUnitOfWork pUnit, ILog pLog) : base(pUnit, pLog)
        {
            _log.Info($"{typeof(ProductController)} ejecutandose");
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult Post(Products pProduct)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var vId = _unit.Products.Insert(pProduct);
            return Ok(new { rId = vId });
        }

        [Route("")]
        [HttpPut]
        public IHttpActionResult Put(Products pProduct)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var boResult = _unit.Products.Update(pProduct);
            if (boResult == false) return BadRequest("No se actualizó el producto");
            return Ok(new { rActualizado = true });
        }

        [Route("{pId}")]
        [HttpGet]
        public IHttpActionResult Get(int pId)
        {
            if (pId <= 0) return BadRequest();
            return Ok(_unit.Products.GetById(pId));
        }

        [Route("list")]
        [HttpGet]
        public IHttpActionResult GetList()
        {
            return Ok(_unit.Products.GetList());
        }
    }
}