using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using EcoRP.Interfaces;

namespace EcoRP.Models
{
    [KnownType(typeof(Product))]
    public  class Product:ISellable
    { 
        [Required]
        public int Id { get;  set;}
        [Required]
        public string Name { get;  set;} 
        [Required]
        public int Serial { get;  set;}
        [Required]
        public int Stock { get; set; }  
        public string Brand { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Warranty { get; set; }
        [Required] 
        [DataType(DataType.Currency)]
        public decimal Price { get; set; } 
        public bool IsChecked { get; set; } 
        public int Amount { get; set; } 

        /// <summary>
        /// Use to insert product into the Repository
        /// </summary>
        /// <param name="name"></param>
        /// <param name="serial"></param>
        /// <param name="stock"></param>
        /// <param name="brand"></param>
        /// <param name="description"></param>
        /// <param name="warranty"></param>
        protected Product(string name, int serial, int stock, string brand, string description, int warranty, decimal price)
        {
            Name = name;
            Serial = serial;
            Stock = stock;
            Brand = brand;
            Description = description;
            Warranty = warranty;
            Price = price;
        }

        /// <summary>
        /// Used to get a product from the database
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="name"></param>
        /// <param name="serial"></param>
        /// <param name="stock"></param>
        /// <param name="brand"></param>
        /// <param name="description"></param>
        /// <param name="warranty"></param>
        protected Product(int id, string name, int serial, int stock, string brand, string description, int warranty,decimal price)
        {
            Id = id;
            Name = name;
            Serial = serial;
            Stock = stock;
            Brand = brand;
            Description = description;
            Warranty = warranty;
            Price = price;
        }
        /// <summary>
        /// Used from ASP.NET MVC Form-Binding
        /// </summary>
        public Product()
        {
             
        }

        /// <summary>
        /// Constructor for ViewModel To add a Product
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="serial"></param>
        /// <param name="stock"></param>
        /// <param name="brand"></param>
        /// <param name="description"></param>
        /// <param name="warranty"></param>
        /// <param name="price"></param>
        /// <param name="isChecked"></param>
        /// <param name="amount"></param>
        public Product(int id, string name, int serial, int stock, string brand, string description, int warranty, decimal price, bool isChecked,int amount)
        {
            Id = id;
            Name = name;
            Serial = serial;
            Stock = stock;
            Brand = brand;
            Description = description;
            Warranty = warranty;
            Price = price;
            IsChecked = isChecked;
            Amount = amount;
        }

     
    }
}