using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EcoRP.Context;
using EcoRP.IRepository;
using EcoRP.Models;
using EcoRP.Repositories.MSSQLRepository;

namespace EcoRP.Logic
{
    public class OrderLogic:IORderRepository
    {
        private OrderContext Context = new OrderContext(new MSSQLOrderRepository());
        public void Insert(Order entity)
        {
            Context.Insert(entity);
        }

        public void Update(int id, Order entity)
        {
            Context.Update(id, entity);
        }

        public void Delete(int id)
        {
            Context.Delete(id);
        }

        public Order GetById(int id)
        {
            return Context.GetById(id);
        }

        public List<Order> GetAll()
        {
            return Context.GetAll();
        }

        public List<Order> GetByEmployeeId(int id)
        {
            return Context.GetByEmployeeId(id);
        }

        public List<Order> GetByCustomerId(int id)
        {
            return Context.GetByCustomerId(id);
        }
    }
}