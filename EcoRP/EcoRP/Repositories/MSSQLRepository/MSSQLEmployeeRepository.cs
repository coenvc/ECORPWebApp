using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using EcoRP.Enums;
using EcoRP.IRepository;
using EcoRP.Models;

namespace EcoRP.Repositories.MSSQLRepository
{
    public class MSSQLEmployeeRepository:Database,IEmployeeRepository 
    {
        private Employee CreateObjectFromReader(SqlDataReader reader)
        {
                                                                            
            int id = Convert.ToInt32(reader["ID"]);
            string Name = Convert.ToString(reader["Naam"]);
            string Surname = Convert.ToString(reader["Achternaam"]);
            string Phonenumber = Convert.ToString(reader["Telefoonnummer"]); 
            string Username = Convert.ToString(reader["Gebruikersnaam"]);
            string Password = Convert.ToString(reader["Wachtwoord"]);  
            string Email = Convert.ToString(reader["Email"]);  
            decimal Salaris = Convert.ToDecimal(reader["Salaris"]);  
            bool Active = Convert.ToBoolean(reader["Active"]);  
            EmployeeRole Role = (EmployeeRole)Convert.ToInt32(reader["RolId"]); 
            string Streetname = Convert.ToString(reader["straatnaam"]); 
            string zipcode = Convert.ToString(reader["postcode"]);
            int housenumber = Convert.ToInt32(reader["huisnummer"]);
            int AddressId = Convert.ToInt32(reader["AdresId"]);
            string city = Convert.ToString(reader["Woonplaats"]);
            Employee employee = new Employee(id, Name, Surname, Email, Phonenumber,new Address(Streetname, city, housenumber, zipcode, AddressId),new Account(Username, Password, Active, id), Role, Salaris);
            return employee;
        }

        public void Insert(Employee entity)
        {
            if (OpenConnection())
            {
                SqlConnection connection = this.Connection;
                SqlCommand InsertEmployee = connection.CreateCommand();
                InsertEmployee.CommandText = "EXECUTE insertEmployee  @Rolid,@Naam,@Achternaam,@Email,@Salaris,@Gebruikersnaam,@Wachtwoord,@Telefoonnummer,@Active,@Straatnaam,@Woonplaats,@Postcode,@Huisnummer";
                InsertEmployee.Parameters.AddWithValue("@Naam", entity.Name);
                InsertEmployee.Parameters.AddWithValue("@Rolid", (int)entity.Role);
                InsertEmployee.Parameters.AddWithValue("@Achternaam", entity.Surname);
                InsertEmployee.Parameters.AddWithValue("@Email", entity.Email);
                InsertEmployee.Parameters.AddWithValue("@Salaris", entity.Salary);
                InsertEmployee.Parameters.AddWithValue("@Gebruikersnaam", entity.Account.Username);
                InsertEmployee.Parameters.AddWithValue("@Wachtwoord", entity.Account.Password);
                InsertEmployee.Parameters.AddWithValue("@Telefoonnummer", entity.Telefoonnummer);
                InsertEmployee.Parameters.AddWithValue("@Active", Convert.ToInt32(entity.Account.IsActive));
                InsertEmployee.Parameters.AddWithValue("@Straatnaam", entity.Address.Streetname);
                InsertEmployee.Parameters.AddWithValue("@Woonplaats", entity.Address.City);
                InsertEmployee.Parameters.AddWithValue("@Postcode", entity.Address.ZipCode);
                InsertEmployee.Parameters.AddWithValue("@Huisnummer", Convert.ToInt32(entity.Address.Housenumber));

                try
                {
                    InsertEmployee.ExecuteNonQuery();
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

        public void Update(int id, Employee entity)
        {
            if (OpenConnection())
            {
                SqlConnection connection = this.Connection;
                SqlCommand InsertEmployee = connection.CreateCommand();
                InsertEmployee.CommandText = "EXECUTE updateEmployee  @Rolid,@Naam,@Achternaam,@Email,@Salaris,@Gebruikersnaam,@Wachtwoord,@Telefoonnummer,@Active,@Straatnaam,@Woonplaats,@Postcode,@Huisnummer,@Id,@AdresId";
                InsertEmployee.Parameters.AddWithValue("@Naam", entity.Name);
                InsertEmployee.Parameters.AddWithValue("@Rolid", (int)entity.Role);
                InsertEmployee.Parameters.AddWithValue("@Achternaam", entity.Surname);
                InsertEmployee.Parameters.AddWithValue("@Email", entity.Email);
                InsertEmployee.Parameters.AddWithValue("@Salaris", entity.Salary);
                InsertEmployee.Parameters.AddWithValue("@Gebruikersnaam", entity.Account.Username);
                InsertEmployee.Parameters.AddWithValue("@Wachtwoord", entity.Account.Password);
                InsertEmployee.Parameters.AddWithValue("@Telefoonnummer", entity.Telefoonnummer);
                InsertEmployee.Parameters.AddWithValue("@Active", Convert.ToInt32(entity.Account.IsActive));
                InsertEmployee.Parameters.AddWithValue("@Straatnaam", entity.Address.Streetname);
                InsertEmployee.Parameters.AddWithValue("@Woonplaats", entity.Address.City);
                InsertEmployee.Parameters.AddWithValue("@Postcode", entity.Address.ZipCode);
                InsertEmployee.Parameters.AddWithValue("@Huisnummer", Convert.ToInt32(entity.Address.Housenumber));
                InsertEmployee.Parameters.AddWithValue("@Id", Convert.ToInt32(entity.Id));
                InsertEmployee.Parameters.AddWithValue("@AdresId", Convert.ToInt32(entity.Address.Id));

                try
                {
                    InsertEmployee.ExecuteNonQuery();
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
            if (OpenConnection())
            {
                string query = "update Medewerker set active = 0 where id = @id";
                try
                {
                    using (SqlCommand command = new SqlCommand(query, Connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception exception)
                {

                }
                finally
                {
                    CloseConnection();
                }
            }
        }

        public Employee GetById(int id)
        {
            if (OpenConnection())
            {
                string query = "select * from medewerker m inner join addres a on a.id = m.adresid where m.id = @id ";
                try
                {
                    using (SqlCommand command = new SqlCommand(query, Connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                Employee employee = CreateObjectFromReader(reader);
                                return employee;

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
            throw new Exception();
        }
        



        public List<Employee> GetAll()
        {
            List<Employee> employees = new List<Employee>();
            if (OpenConnection())
            {
                string query = "select * from Medewerker m inner join Addres a  on m.AdresId = a.ID";
                try
                {
                    using (SqlCommand command = new SqlCommand(query, Connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                employees.Add(CreateObjectFromReader(reader));
                            }
                        }
                    }
                }
                catch (Exception exception)
                {

                }
                finally
                {
                    CloseConnection(); 
                } 

            }
            return employees;
        }

        public Employee GetByUsernameAndPassword(string username, string password)
        {
            if (OpenConnection())
            {
                string query = "select * from medewerker m inner join addres a on a.id = m.adresid where gebruikersnaam = @username and wachtwoord = @password ";
                try
                {
                    using (SqlCommand command = new SqlCommand(query, Connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password); 
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                Employee employee = CreateObjectFromReader(reader);
                                return employee;

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
            throw new Exception();
        }
        }
    }