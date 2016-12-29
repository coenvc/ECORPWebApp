using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcoRP.Models;

namespace EcoRP.IRepository
{
    public interface IRepository<T> where T:class 
    {
        void Insert(T entity);
        void Update(int id, T entity);
        void Delete(int id);
        T GetById(int id);
        List<T> GetAll();
    }
}
