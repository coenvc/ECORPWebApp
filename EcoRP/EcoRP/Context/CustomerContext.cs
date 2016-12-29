using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EcoRP.IRepository;
using EcoRP.Models;

namespace EcoRP.Repositories.Context
{
    public class CustomerContext:IRepository<Customer>
    {
        private IRepository<Customer> Context;

        public CustomerContext(IRepository<Customer>  context)
        {
            this.Context = context;
        }
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