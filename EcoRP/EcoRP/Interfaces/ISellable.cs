using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoRP.Interfaces
{
    /// <summary>
    /// Interface used for products that can be sold, 
    /// For a product to be ISellable it needs to contain  
    /// <Serial></Serial> 
    /// <Stock></Stock> 
    /// </summary>
    public interface ISellable:ICruddable
    {
         int Serial { get; set; }
         int Stock { get; set; }
         string Brand { get; set; }
         string Description { get; set; }
         int Warranty { get; set; } 
         decimal Price { get; set; }
    }
}
