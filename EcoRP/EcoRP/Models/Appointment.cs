using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using EcoRP.Interfaces;

namespace EcoRP.Models
{
    public class Appointment:ICruddable
    {
        public int Id { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)] 
        [Required]
        public DateTime? Date { get; set; }  
        public Customer Customer { get; set; } 
        public Employee Salesman { get; set; }

        public Appointment()
        {
            
        }

        public Appointment(DateTime date, Customer customer, Employee salesman)
        {
            Date = date;
            Customer = customer;
            Salesman = salesman;
        }

        public Appointment(Customer customer, Employee salesman)
        {
            Customer = customer;
            Salesman = salesman;
        }

        public Appointment(int id, DateTime date, Customer customer, Employee salesman)
        {
            Id = id;
            Date = date;
            Customer = customer;
            Salesman = salesman;
        }
    }
}