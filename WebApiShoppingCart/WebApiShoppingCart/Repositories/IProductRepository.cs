using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiShoppingCart.Models;

namespace WebApiShoppingCart
{
    public interface IProductRepository
    { 
        void Add(Product product);
        void Update(int id,Product product);
        List<Product> GetAll();
        Product GetById(int id); 
    }
}
