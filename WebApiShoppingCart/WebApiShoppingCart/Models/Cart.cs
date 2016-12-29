using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiShoppingCart.Models
{
    public class Cart
    {
        public List<Product> Products { get; set; } 
        public decimal Total { get; set; }

        /// <summary>
        /// Calculates the total prices of the items in the shoppingcart
        /// </summary>
        public void CalculateTotal()
        {
            foreach (Product product in Products)
            {
                //Inclusief BTW
                Total += (product.Price/100) * 121; 
            }
        }
        /// <summary>
        /// Removes All products from list
        /// </summary>
        public void Checkout()
        {
            Products.Clear();
        } 
    }
}