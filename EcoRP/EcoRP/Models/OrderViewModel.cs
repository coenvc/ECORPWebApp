using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcoRP.Models
{
    public class OrderViewModel
    { 
        public Customer Customer { get; set; } 
        public Employee Salesman { get; set; }
        public List<Product> Products { get; set; } 
        public decimal Price { get; set; }

        public OrderViewModel(Customer customer, Employee salesman, List<Product> products)
        {
            Customer = customer;
            Salesman = salesman;
            Products = products; 

        }

        public OrderViewModel()
        {
            
        }
    }
}