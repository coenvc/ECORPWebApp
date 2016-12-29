using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoRP.Interfaces
{
    /// <summary>
    /// Interface promising the Class you are using will contain an ID 
    /// This is needed to execute the methods in the Crud class
    /// </summary>
    public interface ICruddable
    {
        int Id { get; set; }
    }
}
