using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EcoRP.Interfaces;
using EcoRP.Context;
using EcoRP.Logic;
using EcoRP.Models;
using EcoRP.Repositories.LocalRepository;
using EcoRP.Repositories.MSSQLRepository;

namespace EcoRP.Controllers
{
    public class SolarPanelController : Controller
    {
        private MSSQLSolarPanelRepository _productContext = new MSSQLSolarPanelRepository(); 
        // GET: MountingMaterial
        public ActionResult Overview()
        {
            return View(_productContext.GetAll().OfType<SolarPanel>());
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(SolarPanel solarPanel)
        {
            _productContext.Insert(solarPanel);
            return View("Overview",_productContext.GetAll().OfType<SolarPanel>());
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            SolarPanel solarPanel = _productContext.GetById(id) as SolarPanel;
            return View(solarPanel);
        }

        public ActionResult Delete(int id)
        {
            _productContext.Delete(id);
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(_productContext.GetById(id) as SolarPanel);
        }

        [HttpPost]
        public ActionResult Edit(SolarPanel solarPanel)
        {
            _productContext.Update(solarPanel.Id, solarPanel);
            return RedirectToAction("Overview");
        } 
    }
}