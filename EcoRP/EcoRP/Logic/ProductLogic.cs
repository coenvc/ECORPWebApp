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
        public void Insert(Product entity)
        {
            Context.Insert(entity);
        }

        public void Update(int id, Product entity)
        {
            Context.Update(id, entity);
        }

        public void Delete(int id)
        {
            Context.Delete(id);
        }

        public Product GetById(int id)
        {
            return Context.GetById(id) as Product;
        }

        public List<Product> GetAll()
        {
            List<Product> ReturnProducts = new List<Product>();
            foreach (ISellable Product in Context.GetAll())
            {
                ReturnProducts.Add(Product as Product);
            }
            return ReturnProducts;
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