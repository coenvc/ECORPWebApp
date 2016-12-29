using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EcoRP.Enums;
using EcoRP.IRepository;
using EcoRP.Models;

namespace EcoRP.Repositories.LocalRepository
{
    public class LocalEmployeeRepository:IEmployeeRepository
    { 

        private LocalCrud<Employee> EmployeeRepository = new LocalCrud<Employee>();

        public LocalEmployeeRepository()
        {
            this.Insert(new Employee("Coen", "van Campenhout", "coenvc@gmail.com","0683992086",new Address(), new Account("coenvc", "Test123", true, 1), EmployeeRole.Salesman, 3000));
        }
        public void Insert(Employee entity)
        {
            EmployeeRepository.Insert(entity);
        }

        public void Update(int id, Employee entity)
        {
            EmployeeRepository.Update(id, entity);
        }

        public void Delete(int id)
        {
            EmployeeRepository.Delete(id);
        }

        public Employee GetById(int id)
        {
            return EmployeeRepository.GetById(id);
        }

        public List<Employee> GetAll()
        {
            return EmployeeRepository.GetAll();
        }

        public Employee GetByUsernameAndPassword(string username, string password)
        {
            return EmployeeRepository.GetAll().FirstOrDefault(x => x.Account.Username == username && x.Account.Password == password);
        }
    }
}