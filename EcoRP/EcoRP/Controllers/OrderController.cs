using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EcoRP.Interfaces;
using EcoRP.IRepository;
using EcoRP.Context;
using EcoRP.Logic;
using EcoRP.Models;
using EcoRP.Repositories.LocalRepository;
using EcoRP.Repositories.MSSQLRepository;

namespace EcoRP.Controllers
{
    public class OrderController : Controller
    {
        private ProductLogic ProductLogic = new ProductLogic();
        private OrderContext _orderContext = new OrderContext(new MSSQLOrderRepository());

     
        [HttpGet]
        public ActionResult Add(OrderViewModel order)
        {
            order = Session["Order"] as OrderViewModel;
            return View("Add",order);
        }

        public ActionResult Finalize()
        {
            Order Final = new Order();
            OrderViewModel FinalOrderViewModel = Session["FinalOrder"] as OrderViewModel;
            Final.Customer = FinalOrderViewModel.Customer;
            Final.Salesman = FinalOrderViewModel.Salesman;
            Final.Products = FinalOrderViewModel.Products; 
            _orderContext.Insert(Final);
            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        public ActionResult AddProduct(OrderViewModel order)
        {
            List<Product> allProducts = ProductLogic.GetAll(); 
            return View(allProducts);
        }

        [HttpPost]
        public ActionResult AddProduct(List<Product> products)
        { 
            //Bij wijze van uitzondering vindt er een deel businesslogic plaats in de controller 
            //Dit is omdat er gebruikt gemaakt moet worden van sessions en dit per definitie alleen gebeurt in ASP.net 
            //Zo blijft C# code alleen C# code en is alles wat er in het framework gebeurt nog steeds netjes losgekoppeld
            List<Product> checkedProducts = ProductLogic.GetCheckedProducts(products);
            if (Session["OrderProducts"] == null)
            {
                Session["OrderProducts"] = checkedProducts;
            }
            else
            {
                List<Product> currentProducts = Session["OrderProducts"] as List<Product>;
                currentProducts.AddRange(checkedProducts);
                products = currentProducts;
            }
            OrderViewModel myOrder = Session["Order"] as OrderViewModel;
            myOrder.Products = checkedProducts;
            myOrder.Price = ProductLogic.CalculateTotal(checkedProducts); 

            return View("Add",myOrder);
        }

        
        [HttpGet]
        public ActionResult AddToOrder(Order order)
        {  
            return View("Add", order);
        }

        [HttpGet]
        public ActionResult Overview(Order order)
        {
            return View(_orderContext.GetAll());
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(_orderContext.GetById(id)); 

        }
    }
}