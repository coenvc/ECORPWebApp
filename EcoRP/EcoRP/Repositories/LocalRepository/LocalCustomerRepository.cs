using System;
using System.Collections.Generic;
using EcoRP.Interfaces;
using EcoRP.IRepository;
using EcoRP.Models;

namespace EcoRP.Repositories.LocalRepository
{
    public class LocalCustomerRepository:ICustomerRepository
    {
        public List<Customer> Customers { get; private set; }
        private LocalCrud<Customer> LocalCrud;

        public LocalCustomerRepository()
        {
            Customers = new List<Customer>()
            {
                new Customer("Thom", "van de Pas", "thomvdpas@hotmail.com", "0612345678",new Address()),
                new Customer("Casper", "Pijnenburg", "cpijnenburg@gmail.com", "0612345678",new Address())
            }; 
            LocalCrud = new LocalCrud<Customer>(Customers);
        }

        public void Insert(Customer entity)
        {
            LocalCrud.Insert(entity);
        }

        public void Update(int id, Customer entity)
        {
            LocalCrud.Update(id, entity);
        }

        public void Delete(int id)
        {
            LocalCrud.Delete(id);
        }

        public Customer GetById(int id)
        {
            return LocalCrud.GetById(id);
        }

        public List<Customer> GetAll()
        {
            return LocalCrud.GetAll();
        }
    }
}