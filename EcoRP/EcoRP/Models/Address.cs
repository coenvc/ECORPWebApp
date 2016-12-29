using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcoRP.Models
{
    public class Address
    { 
        public string Streetname { get; set; } 
        public string City { get; set; } 
        public int Housenumber { get; set; } 
        public string ZipCode { get; set; }  
        public int Id { get; set; }

        public Address(string streetname, string city, int housenumber, string zipCode, int id)
        {
            Streetname = streetname;
            City = city;
            Housenumber = housenumber;
            ZipCode = zipCode;
            Id = id;
        }

        public Address(string streetname, string city, int housenumber, string zipCode)
        {
            Streetname = streetname;
            City = city;
            Housenumber = housenumber;
            ZipCode = zipCode;
        }

        public Address()
        {
            
        }
    }
}