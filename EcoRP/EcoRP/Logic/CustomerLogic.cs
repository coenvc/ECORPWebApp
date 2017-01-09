using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EcoRP.Interfaces;
using EcoRP.Models;
using EcoRP.Repositories.Context;
using EcoRP.Repositories.LocalRepository;
using EcoRP.Repositories.MSSQLRepository;

namespace EcoRP.Logic
{
    public class CustomerLogic:ICustomerRepository
    {
        private CustomerContext Context = new CustomerContext(new MSSQLCustomerRepository());
        public void Insert(Customer entity)
        {
            Context.Insert(entity);
        }

        public void Update(int id, Customer entity)
        {
            Context.Update(id, entity);
        }

        public void Delete(int id)
        {
            Context.Delete(id);
        }

        public Customer GetById(int id)
        {
            return Context.GetById(id);
        }

        public List<Customer> GetAll()
        {
            return Context.GetAll();
        }  

    }
}