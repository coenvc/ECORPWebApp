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
    public class MountingMaterialController : Controller
    {
        private ProductContext _productContext = new ProductContext(new LocalProductRepository());
        // GET: MountingMaterial
        public ActionResult Overview()
        {
            List<MountingMaterial> mountingMaterials = new List<MountingMaterial>();
            foreach (ISellable mountingMaterial in _productContext.GetAll())
            {
                mountingMaterials.Add(mountingMaterial as MountingMaterial);
            }
            return View(mountingMaterials);
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(MountingMaterial mountingMaterial)
        {
            _productContext.Insert(mountingMaterial);
            return View();
        }

        public ActionResult Details(int id)
        {
            MountingMaterial mountingMaterial = _productContext.GetById(id) as MountingMaterial;
            return View(mountingMaterial);
        }

        public ActionResult Delete(int id)
        {
            _productContext.Delete(id);
            return View("Overview");
        } 

    }
}