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

namespace EcoRP.Controllers
{
    public class MountingMaterialController : Controller
    {
       private MountingMaterialLogic Logic = new MountingMaterialLogic();
        // GET: MountingMaterial
        public ActionResult Overview()
        {
            return View(Logic.GetAll());
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(MountingMaterial mountingMaterial)
        {
            Logic.Insert(mountingMaterial);
            return View();
        }

        public ActionResult Details(int id)
        {
            return View(Logic.GetById(id));
        }

        public ActionResult Delete(int id)
        {
            Logic.Delete(id);
            return View("Overview");
        } 

    }
}