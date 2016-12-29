using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiShoppingCart.Models;

namespace WebApiShoppingCart
{
    public class LocalProductRepository:IProductRepository
    {
        private static int _counter = 2;
        private List<Product> _products = new List<Product>()
        {
            new Product("Blauwe Spijkerbroek", 100, 1, "~/Resources/Images/Spijkerbroek1.png", 10),
            new Product("Grijze Sprijkerbroek", 120, 2, "~/Resources/Images/Spijkerbroek2.png", 5)
        }; 
        public void Add(Product product)
        {
            _counter += 1;
            product.Id = _counter;
            _products.Add(product); 
        }

        public void Update(int id, Product product)
        {
            foreach (Product oldProduct in _products.Where(p=>p.Id == id))
            {
                _products.Remove(oldProduct);
                _products.Add(product);
            }
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public Product GetById(int id)
        {
            Product product = _products.FirstOrDefault(p => p.Id == id) as Product;
            return product;
        }
    }
}