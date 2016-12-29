using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EcoRP.IRepository;
using EcoRP.Models;

namespace EcoRP.Repositories.LocalRepository
{
    public class LocalAppointmentRepository:IAppointmentRepository
    {
        private LocalCrud<Appointment> Crud = new LocalCrud<Appointment>(); 
        public void Insert(Appointment entity)
        {
            Crud.Insert(entity);
        }

        public void Update(int id, Appointment entity)
        {
            Crud.Update(id, entity); 
        }

        public void Delete(int id)
        {
            Crud.Delete(id);
        }

        public Appointment GetById(int id)
        {
            return Crud.GetById(id);
        }

        public List<Appointment> GetAll()
        {
            return Crud.GetAll();
        }
        
        public List<Appointment> GetByEmployeeId(int id)
        {
            return Crud.GetAll().Where(x => x.Salesman.Id == id).ToList();
        }
    }
}