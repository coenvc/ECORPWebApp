using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcoRP.Models
{
    public class CustomerEmployeeViewModel
    {
        public Customer customer { get; set; } 
        public List<Employee> SalesMen { get; set; }
    }
}