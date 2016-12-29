using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcoRP.Models
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult View()
        { 

            return View("View");
        }
    }
}