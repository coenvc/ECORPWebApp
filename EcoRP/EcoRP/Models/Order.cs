using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EcoRP.Interfaces;

namespace EcoRP.Models
{
    public class Order:ICruddable
    { 
        public int Id { get; set; } 
        public Employee Salesman { get; set; } 
        public decimal Price { get; set; } 
        public Customer Customer { get; set; }
        public List<Product> Products { get; set; }


        public Order(int id, Employee salesman, decimal price, Customer customer, List<Product> products)
        {
            Id = id;
            Salesman = salesman;
            Price = price;
            Customer = customer;
            Products = products;
        }

        public Order(Employee salesman, decimal price, Customer customer, List<Product> products)
        {
            Salesman = salesman;
            Price = price;
            Customer = customer;
            Products = products;
        }

        public Order()
        {
            
        }
    } 
}