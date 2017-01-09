using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcoRP.Models
{
    public class Customer:Person
    {
        public Employee Salesman { get; set; } 
        public Roof Roof { get; set; }

        public Customer(int id, string name, string surname, string email, string telefoonnummer, Address address, Roof roof) : base(id, name, surname, email, telefoonnummer, address)
        {
            Roof = roof;
        }

        public Customer(string name, string surname, string email, string telefoonnummer, Address address, Roof roof) : base(name, surname, email, telefoonnummer, address)
        {
            Roof = roof;
        }

        public Customer(string name, string surname, string email, string telefoonnummer, Address address, Employee salesman,Roof roof) : base(name, surname, email, telefoonnummer, address)
        {
            Salesman = salesman;
            Roof = roof;
        }

        public Customer(int id, string name, string surname, string email, string telefoonnummer, Address address, Employee salesman,Roof roof) : base(id, name, surname, email, telefoonnummer, address)
        {
            Salesman = salesman;
            Roof = roof;
        }

        public Customer(int id, string name, string surname, string email, string telefoonnummer, Address address) : base(id, name, surname, email, telefoonnummer, address)
        {
        }

        public Customer(string name, string surname, string email, string telefoonnummer, Address address) : base(name, surname, email, telefoonnummer, address)
        {
        }

        public Customer()
        {
            
        } 
    }
}