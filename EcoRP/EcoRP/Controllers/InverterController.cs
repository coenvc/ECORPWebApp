using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EcoRP.Interfaces;
using EcoRP.Context;
using EcoRP.Models;
using EcoRP.Repositories.LocalRepository;
using EcoRP.Repositories.MSSQLRepository;

namespace EcoRP.Controllers
{
    public class InverterController : Controller
    {
        private MSSQLInverterRepository InverterLogic = new MSSQLInverterRepository();
        // GET: MountingMaterial
        public ActionResult Overview()
        {
            return View(InverterLogic.GetAll());
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Inverter Inverter)
        {
            InverterLogic.Insert(Inverter);  
              
            return View();
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            Inverter Inverter = InverterLogic.GetById(id);
            return View(Inverter);
        }
        
        public ActionResult Delete(int id)
        {
            InverterLogic.Delete(id);
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(InverterLogic.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(Inverter inverter)
        {
            InverterLogic.Update(inverter.Id, inverter);
            return View("Overview",InverterLogic.GetAll());
        }

    }
}
