using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using EcoRP.Logic;
using Appointment = EcoRP.Models.Appointment; 
namespace EcoRP.Controllers
{
    public class CalendarController : ApiController
    {
        public AppointmentLogic Logic = new AppointmentLogic();

        public List<Appointment> GetAllAppointments()
        {
            return Logic.GetAll();
        }
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult GetByID(int id)
        {
            return Ok(Logic.GetById(id));
        }
    }
}
