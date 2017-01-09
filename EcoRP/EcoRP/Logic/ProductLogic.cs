using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EcoRP.Context;
using EcoRP.Interfaces;
using EcoRP.IRepository;
using EcoRP.Models;
using EcoRP.Repositories.LocalRepository;

namespace EcoRP.Logic
{
    public class ProductLogic:IRepository<Product>
    {
        private ProductContext Context = new ProductContext(new LocalProductRepository());
        private SolarPanelLogic solarpanelLogic = new SolarPanelLogic();
        private MountingMaterialLogic mountingMaterial = new MountingMaterialLogic();
        private InverterLogic inverterLogic = new InverterLogic();
        public void Insert(Product entity)
        {
            Context.Insert(entity);
            if (entity is SolarPanel)
            {
                solarpanelLogic.Insert(entity as SolarPanel); 
            }
            if (entity is MountingMaterial)
            {
                mountingMaterial.Insert(entity as MountingMaterial);
            }
            else if (entity is Inverter)
            {
                inverterLogic.Insert(entity as Inverter);
            }

        }

        public void Update(int id, Product entity)
        {
            if (entity is SolarPanel)
            {
                solarpanelLogic.Update(id, entity as SolarPanel);
            }
            else if (entity is Inverter)
            {
                inverterLogic.Update(id, entity as Inverter);
            }
            if (entity is MountingMaterial)
            {
                mountingMaterial.Update(id,entity as MountingMaterial);
            }
        }

        public void Delete(int id)
        {
            // Voor nu gebruik ik hier standaard de SolarPanel Repository aangezien deze Methode voor alle objecten hetzelfde is 
            // Een nettere oplossing zou zijn om een MSSQLProductRepository aan te maken en hierin dubbele methodes te verzamelen 
            // dit zou de code efficienter maken
            solarpanelLogic.Delete(id);
        }

        public Product GetById(int id)
        {
            //Omdat de GetAll methode alles uit de lijst ophaalt en er geen apparte MSSQLRepo is voor de parent classe 
            //Haal doe ik nu even een linq query in de lijst in deze Classe
            return GetAll().FirstOrDefault(x => x.Id == id);
        }

        public List<Product> GetAll()
        {
            List<Product> AllProducts = new List<Product>();
            AllProducts.AddRange(mountingMaterial.GetAll());
            AllProducts.AddRange(solarpanelLogic.GetAll());
            AllProducts.AddRange(inverterLogic.GetAll());
            return AllProducts;
        }

        public decimal CalculateTotal(List<Product> products)
        {
            decimal totalPrice = 0;
            foreach (Product product in products )
            {
                totalPrice += product.Price * product.Amount; 
            }

            return totalPrice;
        }

        public List<Product> GetCheckedProducts(List<Product> products)
        {
            List<Product> CheckedProducts = new List<Product>();
            foreach (Product product in products)
            {
                if (product.IsChecked)
                {
                    CheckedProducts.Add(product);
                }
            }

            return CheckedProducts;
        }
    }
}