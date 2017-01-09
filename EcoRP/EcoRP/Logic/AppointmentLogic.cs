using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EcoRP.Context;
using EcoRP.IRepository;
using EcoRP.Models;
using EcoRP.Repositories.LocalRepository;
using EcoRP.Repositories.MSSQLRepository;

namespace EcoRP.Logic
{
    public class AppointmentLogic :IAppointmentRepository
    {
        AppointmentContext Context = new AppointmentContext(new MSSQLAppointmentRepository());

        /// <summary>
        /// Inserts ann appointment
        /// </summary>
        /// <param name="entity"></param>
        public void Insert(Appointment entity)
        {
            Context.Insert(entity);
        }
        /// <summary>
        /// Updates an appointment 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        public void Update(int id, Appointment entity)
        { 

            Context.Update(id, entity);
        }
        /// <summary>
        /// Deletes An Appointment from a repository
        /// </summary>
        /// <param name="id">The id of the appointment that will be deleted</param>
        public void Delete(int id)
        {
            Context.Delete(id);
        }
        /// <summary>
        /// Gets an appointment by an id 
        /// </summary>
        /// <param name="id">The appointment of the Id that is needed</param>
        /// <returns></returns>
        public Appointment GetById(int id)
        {
            return Context.GetById(id);
        } 
        /// <summary>
        /// Returns all appointments 
        /// </summary>
        /// <returns>A list of appointments</returns>
        public List<Appointment> GetAll()
        {
            return Context.GetAll();
        }
        /// <summary>
        /// Gets a list of Appointments belonging to an Employee
        /// </summary>
        /// <param name="id">The id of the Employee</param>
        /// <returns></returns>
        public List<Appointment> GetByEmployeeId(int id)
        {
            return Context.GetByEmployeeId(id);
        }

        public List<Appointment> GetByCustomerId(int id)
        {
            return Context.GetByCustomerId(id);
        }
        /// <summary>
        /// Gets a list of appointments that are planned after the current datetime
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Appointment> GetPlannedAppointmentsByEmployee(int id)
        {
            List<Appointment> futureAppointments = this.GetByCustomerId(id).Where(x => x.Date > DateTime.Now).ToList();

            return futureAppointments;
        } 



    }
}