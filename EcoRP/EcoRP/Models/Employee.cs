using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using EcoRP.Enums;
using EcoRP.Interfaces;

namespace EcoRP.Models
{
    public class Employee:Person
    {
        public Account Account { get; set; }
        [Required]
        public EmployeeRole Role { get; set; }
        [Required]
        public decimal Salary { get; set; }

        public Employee(int id, string name, string surname, string email, string telefoonnummer, Address address, Account account, EmployeeRole role, decimal salary) : base(id, name, surname, email, telefoonnummer, address)
        {
            Account = account;
            Role = role;
            Salary = salary;
        }

        public Employee(string name, string surname,  string email, string telefoonnummer, Address address, Account account, EmployeeRole role, decimal salary) : base(name, surname, email, telefoonnummer, address)
        {
            Account = account;
            Role = role;
            Salary = salary;
        }

        public Employee(Account account, EmployeeRole role, decimal salary)
        {
            Account = account;
            Role = role;
            Salary = salary;
        }

        public Employee()
        {
            
        }
    }
}