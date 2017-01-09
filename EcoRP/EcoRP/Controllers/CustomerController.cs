using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EcoRP.Logic;
using EcoRP.Models;

namespace EcoRP.Controllers
{
    public class CustomerController : Controller
    {
        private CustomerLogic Customers = new CustomerLogic();
        private OrderLogic Orders = new OrderLogic();
        private AppointmentLogic Appointments = new AppointmentLogic();
        [HttpGet]
        public ActionResult Index()
        {
            return View(Customers.GetAll());
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            CustomerProfileViewModel Customer = new CustomerProfileViewModel(Customers.GetById(id),Appointments.GetByCustomerId(id), Orders.GetByCustomerId(id));
            return View(Customer);
        }

        [HttpGet]
        public ActionResult CreateOrder(int id )
        {
            OrderViewModel CustomerOrder = new OrderViewModel();
            CustomerOrder.Customer = Customers.GetById(id);
            CustomerOrder.Salesman = Session["loggedInEmployee"] as Employee;
            Session["Order"] = CustomerOrder;
            return RedirectToAction("Add", "Order");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(); 
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            Customer customer = new Customer();
            customer.Name = collection["Name"];
            customer.Surname = collection["Surname"];
            customer.Email = collection["Email"];
            customer.Telefoonnummer = collection["Telefoonnummer"];
            customer.Roof = new Roof(Convert.ToInt32(collection["Roof.Width"]),Convert.ToInt32(collection["Roof.Height"]),Convert.ToInt32(collection["Roof.Angle"]));
            customer.Address = new Address(collection["Address.Streetname"], collection["Address.City"], Convert.ToInt32(collection["Address.Housenumber"]),collection["Address.ZipCode"]); 
            Customers.Insert(customer);
            return View("Index"); 
        }

        [HttpGet]
        public ActionResult Edit (int id)
        {
            return View(Customers.GetById(id));
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Customer customer)
        {
            int id = customer.Id;
            Customers.Update(customer.Id, customer);
            CustomerProfileViewModel ProfileCustomer = new CustomerProfileViewModel(customer,
                Appointments.GetByCustomerId(id), Orders.GetByCustomerId(id));
            return View("Details", ProfileCustomer);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Customers.Delete(id);
            return View("Index",Customers.GetAll());
        }
    }
}