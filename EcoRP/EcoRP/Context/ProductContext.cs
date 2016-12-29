using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EcoRP.Interfaces;
using EcoRP.IRepository;
using EcoRP.Models;

namespace EcoRP.Context
{
    public class ProductContext : IRepository<ISellable>
    {
        private IRepository<ISellable> Repository;

        public ProductContext(IRepository<ISellable> repository)
        {
            this.Repository = repository;
        }

        public List<SolarPanel> GetAllSolarPanels()
        {
            return Repository.GetAll().OfType<SolarPanel>().Select(product => product).ToList();
        }

        public List<Inverter> GetAllInverters()
        {
            return Repository.GetAll().OfType<Inverter>().Select(product => product).ToList();
        }

        public List<MountingMaterial> GetAllMountingMaterial()
        {
            return Repository.GetAll().OfType<MountingMaterial>().Select(product => product).ToList();
        }


        public List<Product> GetAllProducts()
        {
            return Repository.GetAll().Cast<Product>().ToList();
        }

        public void Insert(ISellable entity)
        {
            Repository.Insert(entity);
        }

        public void Update(int id, ISellable entity)
        {
            Repository.Update(id,entity);
        }

        public void Delete(int id)
        {
            Repository.Delete(id);
        } 

        public ISellable GetById(int id)
        {
            return Repository.GetById(id);
        }

        public List<ISellable> GetAll()
        {
            return Repository.GetAll();
        }
    }
}