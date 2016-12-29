using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using EcoRP.Interfaces;

namespace EcoRP.Models
{
    public abstract class Person:ICruddable
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [DisplayName("E-Mailadres")]
        public string Email { get; set; }
        [Required]
        [DisplayName("Telefoonnummer")]
        [DataType(DataType.PhoneNumber)]
        public string Telefoonnummer { get; set; } 
        public Address Address { get; set; }

        protected Person(int id, string name, string surname, string email, string telefoonnummer, Address address)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Email = email;
            Telefoonnummer = telefoonnummer;
            Address = address; 
        }

        protected Person(string name, string surname, string email, string telefoonnummer, Address address)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Telefoonnummer = telefoonnummer;
            Address = address;
        }

        public Person()
        {
            
        }

    }
}