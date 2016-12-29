using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiShoppingCart.Models;

namespace WebApiShoppingCart
{
    public class ProductLogic:IProductRepository
    {
        private IProductRepository _productRepository;
        public Cart Cart = new Cart();

        public ProductLogic(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        public void Add(Product product)
        {
            _productRepository.Add(product);
        }

        public void Update(int id, Product product)
        {
            _productRepository.Update(id, product);
        }

        public List<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public Product GetById(int id)
        {
            return _productRepository.GetById(id);   
        }

        public void AddToCart(Product product)
        {
            Cart.Products.Add(product);
        }
    }
}