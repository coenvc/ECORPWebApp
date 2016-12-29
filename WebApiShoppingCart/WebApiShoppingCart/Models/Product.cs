using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiShoppingCart.Models
{
    public class Product
    { 
        public string Name { get; set; } 
        public decimal Price { get; set; } 
        public int Id { get; set; } 
        public string PorductImage { get; set; } 
        public int Stock { get; set; }

        public Product()
        {
             
        }

        public Product(string name, decimal price, int id, string porductImage, int stock)
        {
            Name = name;
            Price = price;
            Id = id;
            PorductImage = porductImage;
            Stock = stock;
        }

        public Product(string name, decimal price, string porductImage, int stock)
        {
            Name = name;
            Price = price;
            PorductImage = porductImage;
            Stock = stock;
        }
    }
}