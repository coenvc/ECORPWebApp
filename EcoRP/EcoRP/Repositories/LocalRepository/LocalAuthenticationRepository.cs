using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EcoRP.IRepository;
using EcoRP.Models;

namespace EcoRP.Repositories.LocalRepository
{
    public class LocalAuthenticationRepository:IAuthenticationRepository
    {
        static DateTime GeboorteDatum = new DateTime(1996, 08, 23);
        private List<Account> _Accounts = new List<Account>
        {
            new Account("coenvc","Denia123",true,001)
        };
        public bool Login(string username, string password)
        {
            foreach (Account account in _Accounts)
            {
                if (account.Username == username && account.Password == password)
                {
                    return true;
                } 
            }
            return false;
        }

    }
}