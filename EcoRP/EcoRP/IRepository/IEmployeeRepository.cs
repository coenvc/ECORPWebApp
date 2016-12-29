using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcoRP.Models;

namespace EcoRP.IRepository
{
    public interface IEmployeeRepository:IRepository<Employee>
    {
        Employee GetByUsernameAndPassword(string username, string password);
    }
}
