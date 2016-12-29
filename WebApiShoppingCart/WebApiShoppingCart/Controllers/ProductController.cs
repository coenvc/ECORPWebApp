using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiShoppingCart.Models;
using static WebApiShoppingCart.ProductLogic;
namespace WebApiShoppingCart.Controllers
{
    public class ProductController : ApiController
    {
        private ProductLogic _productLogic = new ProductLogic(new LocalProductRepository());

        public IEnumerable<Product> GetAllProducts()
        {
            return _productLogic.GetAll();
        }

        public IHttpActionResult GetProduct(int id)
        {
             
            Product product = _productLogic.GetById(id);

            if (product == null)
            {
                return NotFound();
            }

                return Ok(product);
            
            
        }



    }
}
