using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EcoRP.Context;
using EcoRP.Exceptions;
using EcoRP.IRepository;
using EcoRP.Models;
using EcoRP.Repositories.LocalRepository;
using EcoRP.Repositories.MSSQLRepository;

namespace EcoRP.Logic
{
    public class EmployeeLogic:IEmployeeRepository
    {
        private EmployeeContext Context = new EmployeeContext(new MSSQLEmployeeRepository());
        public void Insert(Employee entity)
        {
            Context.Insert(entity);
        }

        public void Update(int id, Employee entity)
        {
            Context.Update(id, entity);
        }

        public void Delete(int id)
        {
            Context.Delete(id);
        }

        public Employee GetById(int id)
        {
            return Context.GetById(id);
        }

        public List<Employee> GetAll()
        {
            return Context.GetAll();
        }

        public Employee GetByUsernameAndPassword(string username, string password)
        {
            return Context.GetByUsernameAndPassword(username,password); 
        }

        public Employee Login(string username, string password)
        {
            Employee LoggedInemployee = this.GetByUsernameAndPassword(username, password);
            if (LoggedInemployee.Account.IsActive)
            {
                return LoggedInemployee;
            }
            else
            {
                throw new AccountException();
            }
        } 


    }
}