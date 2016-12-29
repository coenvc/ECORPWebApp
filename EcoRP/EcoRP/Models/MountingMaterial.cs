using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EcoRP.Interfaces;

namespace EcoRP.Models
{
    public class MountingMaterial : Product
    {
        public string Materiaal { get; set; }

        public MountingMaterial(string name, int serial, int stock, string brand, string description, int warranty,
            string materiaal,decimal price) : base(name, serial, stock, brand, description, warranty,price)
        {
            Materiaal = materiaal;
        }

        public MountingMaterial(int id, string name, int serial, int stock, string brand, string description,
            int warranty, string materiaal,decimal price) : base(id, name, serial, stock, brand, description, warranty,price)
        {
            Materiaal = materiaal;
        }

        public MountingMaterial()
        {

        }
    }
}