using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EcoRP.Interfaces;

namespace EcoRP.Models
{
    public class MountingMaterial : Product
    {
        public string Material { get; set; }

        public MountingMaterial(string name, int serial, int stock, string brand, string description, int warranty,
            string material,decimal price) : base(name, serial, stock, brand, description, warranty,price)
        {
            Material = material;
        }

        public MountingMaterial(int id, string name, int serial, int stock, string brand, string description,
            int warranty, string material,decimal price) : base(id, name, serial, stock, brand, description, warranty,price)
        {
            Material = material;
        }

        public MountingMaterial()
        {

        }
    }
}