using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EcoRP.Enums;
using EcoRP.Interfaces;

namespace EcoRP.Models
{
    public class SolarPanel : Product
    { 
        public int Power { get; set; }
        public CelType Celtype { get; set; } 
        public string Color { get; set; } 
        public int Length { get; set; } 
        public int Width { get; set; } 
        public int Height { get; set; } 

        public SolarPanel(int power, CelType celtype,string color,int length, int width,int height,string name, int serial, int stock, string brand, string description, int warranty,decimal price) : base(name, serial, stock, brand, description, warranty,price)
        {
            Power = power;
            Celtype = celtype;
            Color = color;
            Length = length;
            Width = width;
            Height = height;  
        }

        public SolarPanel(int id, string name, int serial, int stock, string brand, string description, int warranty, int power, CelType celtype, string color, int length, int width, int height,decimal price) : base(id, name, serial, stock, brand, description, warranty,price)
        {
            Power = power;
            Celtype = celtype;
            Color = color;
            Length = length;
            Width = width;
            Height = height;
        }

        public SolarPanel()
        {
        }
    }
}