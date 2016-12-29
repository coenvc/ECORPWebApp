using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EcoRP.IRepository;
using EcoRP.Models;

namespace EcoRP.Context
{
    public class OrderContext:IRepository<Order>
    {
        private IRepository<Order> Context; 
        public OrderContext(IRepository<Order> context)
        {
            Context = context;
        }
        public void Insert(Order order)
        {
            Context.Insert(order);
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
            Order order = Context.GetById(id);
            return order;
        }

        public List<Order> GetAll()
        {
            List<Order> orders = Context.GetAll();
            return orders;
        }
    }
}