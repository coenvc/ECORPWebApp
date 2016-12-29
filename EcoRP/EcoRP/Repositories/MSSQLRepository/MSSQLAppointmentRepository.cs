using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using EcoRP.IRepository;
using EcoRP.Models;

namespace EcoRP.Repositories.MSSQLRepository
{
    public class MSSQLAppointmentRepository:Database,IAppointmentRepository
    {
        private MSSQLEmployeeRepository EmployeeRepository = new MSSQLEmployeeRepository();
        private MSSQLCustomerRepository CustomerRepository = new MSSQLCustomerRepository();
        public void Insert(Appointment entity)
        {
            if (OpenConnection())
            {
                string query = "insert into Afspraak(MedewerkerId,KlantId,Datum) values(@MedewerkerId,@KlantId,@Datum)";
                try
                {
                    using (SqlCommand command = new SqlCommand(query, Connection))
                    {
                        command.Parameters.AddWithValue("@MedewerkerId", entity.Salesman.Id);
                        command.Parameters.AddWithValue("@KlantId", entity.Customer.Id);
                        command.Parameters.AddWithValue("@Datum", Convert.ToDateTime(entity.Date));

                        command.ExecuteNonQuery();
                    }
                }
                catch (SqlException exception)
                {

                }
                finally
                {
                    CloseConnection();
                }

            }
            }
        

        public void Update(int id, Appointment entity)
        {
            string query = "update afspraak set KlantId = @KlantId, MedewerkerId = @MedewerkerId, Datum = @Datum";
            if (OpenConnection())
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(query, Connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                catch (SqlException exception)
                {

                }
                finally
                {
                    CloseConnection(); 
                } 
            }
         
            
        }

        public void Delete(int id)
        {
            string query = "delete Afspraak where id = @id";
            if (OpenConnection())
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(query, Connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.ExecuteNonQuery();
                    }
                }
                catch (SqlException exception)
                {

                }
                finally
                {
                    CloseConnection();
                }
            }
    }

        public Appointment GetById(int id)
        {
            string query = "select * from appoint where id = @id";
            if (OpenConnection())
            {
                using (SqlCommand command = new SqlCommand(query,Connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    try
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            Appointment appointment = CreateFromReader(reader);
                            return appointment;
                        }
                    }
                    catch (SqlException exception)
                    {

                    }
                    finally
                    {
                        CloseConnection();
                    }
                }
            }
            throw new Exception();
        }

        public List<Appointment> GetAll()
        {
            List <Appointment> appointments = new List<Appointment>(); 
            string query = "select * from Afspraak";
            if (OpenConnection())
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(query, Connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                appointments.Add(CreateFromReader(reader));
                            }
                        }
                    }

                }
                catch (SqlException exception)
                {

                }
                finally
                {
                    CloseConnection();
                }
            }
            return appointments;
        } 

        public List<Appointment> GetByEmployeeId(int id)
        {
            List<Appointment> appointments = new List<Appointment>();
            string query = "select * from Afspraak where MedewerkerId = @id";
            if (OpenConnection())
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(query, Connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                appointments.Add(CreateFromReader(reader));
                            }
                        }
                    }

                }
                catch (SqlException exception)
                {

                }
                finally
                {
                    CloseConnection();
                }
            }
            return appointments;
        }

        private Appointment CreateFromReader(SqlDataReader reader)
        {
            int customerId = Convert.ToInt32(reader["KlantId"]);
            int EmployeeId = Convert.ToInt32(reader["MedewerkerId"]);
            Customer Customer = CustomerRepository.GetById(customerId);
            Employee Employee = EmployeeRepository.GetById(EmployeeId);
            DateTime Datum = Convert.ToDateTime(reader["Datum"]);
            int Id = Convert.ToInt32(reader["Id"]);
            Appointment appointment = new Appointment(Id, Datum, Customer, Employee); 

            return appointment;
        }
    }
}