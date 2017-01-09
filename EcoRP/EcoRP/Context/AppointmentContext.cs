using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EcoRP.IRepository;
using EcoRP.Models;

namespace EcoRP.Context
{
    public class AppointmentContext:IAppointmentRepository
    {
        private IAppointmentRepository Context;
        public AppointmentContext(IAppointmentRepository context)
        {
            Context = context;
        }
        public void Insert(Appointment entity)
        {
            Context.Insert(entity);
        }

        public void Update(int id, Appointment entity)
        {
            Context.Update(id, entity);
        }

        public void Delete(int id)
        {
            Context.Delete(id);
        }

        public Appointment GetById(int id)
        {
            return Context.GetById(id);
        }

        public List<Appointment> GetAll()
        {
            return Context.GetAll();
        }

        public List<Appointment> GetByEmployeeId(int id)
        {
            return Context.GetByEmployeeId(id);
        }

        public List<Appointment> GetByCustomerId(int id)
        {
            return Context.GetByCustomerId(id);
        }
    }
}