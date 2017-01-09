using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EcoRP.Enums;
using EcoRP.Interfaces;
using EcoRP.IRepository;
using EcoRP.Models;

namespace EcoRP.Repositories.LocalRepository
{
    public class LocalOrderRepository : IRepository<Order>
    {
        private List<Order> LocalOrders = new List<Order>();
        private LocalCrud<Order> OrderRepository = new LocalCrud<Order>();
        public LocalOrderRepository()
        {
            List<Product> Products = new List<Product>();
            SolarPanel dummySolarpanel1 = new SolarPanel(270, Enums.CelType.Poly, "Zwart", 100, 20, 10, "Solarmax 270", 001, 10, "Solarmax", "Dit is een mooi zonnepaneel", 20,250);
            Inverter dummyInverter1 = new Inverter("KLNE 3600", 003, 10, "KLNE", "Dit is een goede omvormer", 10, 3600, 10, "Oranje", true,1000,100,200);
            MountingMaterial dummyMountingMaterial1 = new MountingMaterial("Aluminium Frame", 004, 100, "Custom made", "Dit is montagemateriaal", 10, "Aluminium",10);
            Products.Add(dummySolarpanel1);
            Products.Add(dummyInverter1);
            Products.Add(dummyMountingMaterial1);
            Employee orderEmployee = new Employee("Coen", "van Campenhout", "coenvc@gmail.com", "0683992086", new Address(), new Account("coenvc", "Test123", true, 1), EmployeeRole.Salesman, 3000);
            Customer orderCustomer = new Customer("Jan", "Janssen", "j.janssen@crackmail.com", "068008522", new Address(), orderEmployee,new Roof());
            Order dummyOrder = new Order(orderEmployee, 10000, orderCustomer, Products);
            LocalOrders.Add(dummyOrder);
        }

        public void Insert(Order entity)
        {
            OrderRepository.Insert(entity);
        }

        public void Update(int id, Order entity)
        {
            OrderRepository.Update(id, entity);
        }

        public void Delete(int id)
        {
            OrderRepository.Delete(id);
        }

        public Order GetById(int id)
        {
            return OrderRepository.GetById(id);
        }

        public List<Order> GetAll()
        {
            return OrderRepository.GetAll();
        }



    }
}