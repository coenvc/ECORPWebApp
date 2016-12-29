using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcoRP.Models;

namespace EcoRP.IRepository
{
    public interface IAuthenticationRepository
    {
        bool Login(string username, string password);
    }
}
