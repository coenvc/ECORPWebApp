using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EcoRP.Enums;
using EcoRP.Context;
using EcoRP.Logic;
using EcoRP.Models;
using EcoRP.Repositories.LocalRepository;

namespace EcoRP.Controllers
{
    public class AuthController : Controller
    {
        private EmployeeLogic EmployeeLogic = new EmployeeLogic();
        // GET: Auth
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        { 
            return View();
        }
         
        [HttpPost]
        public ActionResult Login(Account account )
        {
            try
            {
                Session["LoggedinEmployee"] = EmployeeLogic.Login(account.Username, account.Password);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception exception)
            {
                return RedirectToAction("Login");
            }
        }
        } 


    }
