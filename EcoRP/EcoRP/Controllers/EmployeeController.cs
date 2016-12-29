using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EcoRP.Logic;
using EcoRP.Models;

namespace EcoRP.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeLogic Logic = new EmployeeLogic();
        // GET: Employee
        public ActionResult Index()
        {
            return View(Logic.GetAll());
        }

        public ActionResult Details(int id)
        {
            return View(Logic.GetById(id));
        } 

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            Logic.Insert(employee);

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
           return View(Logic.GetById(id)); 
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            Logic.Update(employee.Id, employee);
            return View("Details",Logic.GetById(employee.Id)); 
        }
    }
}