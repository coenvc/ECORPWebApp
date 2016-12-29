using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EcoRP.Models
{
    public class Inverter:Product
    {
        [Required]
        public int Power { get; set; }
        [Required]
        public int Length { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public bool Monitoring { get; set; }  
        [Required] 
        public int Width { get; set; } 
        [Required] 
        public int Height { get; set; }

        public Inverter(string name, int serial, int stock, string brand, string description, int warranty, int power, int length, string color, bool monitoring,decimal price,int width,int height) : base(name, serial, stock, brand, description, warranty,price)
        {
            Power = power;
            Length = length;
            Color = color;
            Monitoring = monitoring;
            Width = width;
            Height = height;
        }

        public Inverter(int id, string name, int serial, int stock, string brand, string description, int warranty, int power, int length, string color, bool monitoring,decimal price, int width, int height) : base(id, name, serial, stock, brand, description, warranty,price)
        {
            Power = power;
            Length = length;
            Color = color; 
            Monitoring = monitoring;
            Width = width;
            Height = height;
        }

        public Inverter()
        {
            
        }
    }
}