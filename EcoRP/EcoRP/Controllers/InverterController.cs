using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EcoRP.Interfaces;
using EcoRP.Context;
using EcoRP.Models;
using EcoRP.Repositories.LocalRepository;

namespace EcoRP.Controllers
{
    public class InverterController : Controller
    {
        private ProductContext _productContext = new ProductContext(new LocalProductRepository());
        // GET: MountingMaterial
        public ActionResult Overview()
        {
            List<Inverter> Inverters = new List<Inverter>();
            foreach (ISellable inverter in _productContext.GetAll())
            {
                if(inverter is Inverter) {  
                    Inverters.Add(inverter as Inverter);
                }
            }
            return View(Inverters);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Inverter Inverter)
        {
            _productContext.Insert(Inverter);  
              
            return View();
        }

        public ActionResult Details(int id)
        {
            Inverter Inverter = _productContext.GetById(id) as Inverter;
            return View(Inverter);
        }
         
        public ActionResult Delete(int id)
        {
            _productContext.Delete(id);
            return View();
        }
    }
}
