using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcoRP.Models;

namespace EcoRP.IRepository
{
    public interface IAppointmentRepository:IRepository<Appointment>
    {  
        /// <summary>
        /// gets a list of appointments of a selected Employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<Appointment> GetByEmployeeId(int id);

        List<Appointment> GetByCustomerId(int id);
    }
}
