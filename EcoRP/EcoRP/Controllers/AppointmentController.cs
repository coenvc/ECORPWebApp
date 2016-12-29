using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EcoRP.Logic;
using EcoRP.Models;

namespace EcoRP.Controllers
{
    public class AppointmentController : Controller
    {
        private AppointmentLogic _appointment = new AppointmentLogic();
        private CustomerLogic _customer = new CustomerLogic();
        private EmployeeLogic _employee = new EmployeeLogic();
        // GET: Appointment
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create(int id)
        {
            Appointment appointment = new Appointment(_customer.GetById(id), Session["loggedInEmployee"] as Employee);
            Session["AppointmentBeforedate"] = appointment;
            return View(appointment);
        }  
        [HttpPost]
        public ActionResult Create(Appointment appointment)
        {
            Appointment oldAppointment = Session["AppointmentBeforedate"] as Appointment;
            appointment.Salesman = oldAppointment.Salesman;
            appointment.Customer = oldAppointment.Customer; 
            _appointment.Insert(appointment);
            Session.Remove("AppointmentBeforedate");
            return View(appointment);
        }

        [HttpGet]
        public ActionResult MyAppointments()
        {   
            Employee loggedInEmployee = Session["loggedInEmployee"] as Employee;  
            return View(_appointment.GetByEmployeeId(loggedInEmployee.Id));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(_appointment.GetById(id)); 
        }

        [HttpGet]
        public ActionResult Edit(Appointment appointment)
        {
            _appointment.Update(appointment.Id, appointment);
            return View();
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(_appointment.GetById(id)); 
        }

    }
}