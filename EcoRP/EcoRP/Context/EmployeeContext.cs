using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EcoRP.IRepository;
using EcoRP.Models;
using EcoRP.Repositories.LocalRepository;

namespace EcoRP.Context
{
    public class EmployeeContext:IEmployeeRepository
    {
        private IEmployeeRepository EmployeeRepository;
        public EmployeeContext(IEmployeeRepository employeeRepository)
        {
            EmployeeRepository = employeeRepository;
        }

        public void Insert(Employee employee)
        {
            EmployeeRepository.Insert(employee);
        }

        public void Delete(int id)
        {
            EmployeeRepository.Delete(id);
        }

        public void Update(int id, Employee employee)
        {
            EmployeeRepository.Update(id, employee);
        }

        public Employee GetById(int id)
        {
            Employee SelectedEmployee = EmployeeRepository.GetById(id);

            return SelectedEmployee;
        }

        public List<Employee> GetAll()
        {
            List<Employee> AllEmployees = EmployeeRepository.GetAll();

            return AllEmployees;
        }

        public Employee GetByUsernameAndPassword(string username, string password)
        {
            return EmployeeRepository.GetByUsernameAndPassword(username, password);
            
        }
    }
}