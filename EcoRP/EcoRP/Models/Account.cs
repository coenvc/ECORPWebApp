using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcoRP.Models
{
    public class Account
    {
        public string Username { get; set; } 
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public int Id { get; private set; }

        public Account(string username, string password, bool isActive, int employeeId, int id)
        {
            Username = username;
            Password = password;
            IsActive = isActive;
            Id = id;
        }

        public Account(string username, string password, bool isActive, int employeeId)
        {
            Username = username;
            Password = password;
            IsActive = isActive;
        }

        public Account()
        {
            
        }
    }
}