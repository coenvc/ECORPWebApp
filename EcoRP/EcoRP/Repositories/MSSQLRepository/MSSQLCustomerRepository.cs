using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using EcoRP.Enums;
using EcoRP.Interfaces;
using EcoRP.Models;

namespace EcoRP.Repositories.MSSQLRepository
{
    public class MSSQLCustomerRepository:Database,ICustomerRepository
    {
        private Customer CreateObjectFromReader(SqlDataReader reader)
        {

            int id = Convert.ToInt32(reader["klantid"]);
            string Name = Convert.ToString(reader["Naam"]);
            string Surname = Convert.ToString(reader["Achternaam"]);
            string Phonenumber = Convert.ToString(reader["Telefoonnummer"]);
            string Email = Convert.ToString(reader["Email"]);
            string Streetname = Convert.ToString(reader["straatnaam"]);
            string zipcode = Convert.ToString(reader["postcode"]);
            int housenumber = Convert.ToInt32(reader["huisnummer"]);
            int AddressId = Convert.ToInt32(reader["AddresId"]);
            string city = Convert.ToString(reader["Woonplaats"]);
            int Width = Convert.ToInt32(reader["Breedte"]);
            int Height = Convert.ToInt32(reader["Lengte"]);
            int Angle = Convert.ToInt32(reader["HellingsHoek"]);
            int RoofId = Convert.ToInt32(reader["DakId"]);

            Customer customer = new Customer(id, Name, Surname, Email, Phonenumber,
                new Address(Streetname, city, housenumber, zipcode, AddressId), new Roof(Width, Height, Angle, RoofId));
            return customer;
        }
        public void Insert(Customer entity)
        {
            if (OpenConnection())
            {
                try
                {
                    SqlConnection connection = this.Connection;
                    SqlCommand InsertCustomer = connection.CreateCommand();
                    InsertCustomer.CommandText = "EXECUTE insertCustomer @Naam,@Achternaam,@Email,@Telefoonnummer,@Straatnaam,@Woonplaats,@Postcode,@Huisnummer,@Lengte,@Breedte,@Hellingshoek";
                    InsertCustomer.Parameters.AddWithValue("@Naam", entity.Name);
                    InsertCustomer.Parameters.AddWithValue("@Achternaam", entity.Name);
                    InsertCustomer.Parameters.AddWithValue("@Email", entity.Email);
                    InsertCustomer.Parameters.AddWithValue("@Telefoonnummer", entity.Telefoonnummer);
                    InsertCustomer.Parameters.AddWithValue("@Straatnaam", entity.Address.Streetname);
                    InsertCustomer.Parameters.AddWithValue("@Woonplaats", entity.Address.City);
                    InsertCustomer.Parameters.AddWithValue("@Postcode", entity.Address.ZipCode);
                    InsertCustomer.Parameters.AddWithValue("@Huisnummer", entity.Address.Housenumber);
                    InsertCustomer.Parameters.AddWithValue("@Lengte", entity.Roof.Height);
                    InsertCustomer.Parameters.AddWithValue("@Breedte", entity.Roof.Width);
                    InsertCustomer.Parameters.AddWithValue("@Hellingshoek", entity.Roof.Angle);
                    InsertCustomer.ExecuteNonQuery();
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

        public void Update(int id, Customer entity)
        {
            if (OpenConnection())
            {
                try
                {
                    SqlConnection connection = this.Connection;
                    SqlCommand InsertCustomer = connection.CreateCommand();
                    InsertCustomer.CommandText = "EXECUTE updateCustomer @Naam,@Achternaam,@Email,@Telefoonnummer,@Straatnaam,@Woonplaats,@Postcode,@Huisnummer,@Lengte,@Breedte,@Hellingshoek,@DakId,@KlantId,@AdresId";
                    InsertCustomer.Parameters.AddWithValue("@Naam", entity.Name);
                    InsertCustomer.Parameters.AddWithValue("@Achternaam", entity.Name);
                    InsertCustomer.Parameters.AddWithValue("@Email", entity.Email);
                    InsertCustomer.Parameters.AddWithValue("@Telefoonnummer", entity.Telefoonnummer);
                    InsertCustomer.Parameters.AddWithValue("@Straatnaam", entity.Address.Streetname);
                    InsertCustomer.Parameters.AddWithValue("@Woonplaats", entity.Address.City);
                    InsertCustomer.Parameters.AddWithValue("@Postcode", entity.Address.ZipCode);
                    InsertCustomer.Parameters.AddWithValue("@Huisnummer", entity.Address.Housenumber);
                    InsertCustomer.Parameters.AddWithValue("@Lengte", entity.Roof.Height);
                    InsertCustomer.Parameters.AddWithValue("@Breedte", entity.Roof.Width);
                    InsertCustomer.Parameters.AddWithValue("@Hellingshoek", entity.Roof.Angle);
                    InsertCustomer.Parameters.AddWithValue("@DakId", entity.Roof.Id);
                    InsertCustomer.Parameters.AddWithValue("@AdresId", entity.Address.Id);
                    InsertCustomer.Parameters.AddWithValue("@KlantId", entity.Id);
                    InsertCustomer.ExecuteNonQuery();
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
                string query = "update klant set active = 0 where id = @id";
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

        public Customer GetById(int id)
        { 
            if (OpenConnection())
            {
                string query =
                    "select *, k.id as klantid from Klant k inner join dak d on d.id = k.DakId inner join Addres a on a.ID = k.AddresId where k.ID = @id";
                try
                {
                    using (SqlCommand command = new SqlCommand(query, Connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Customer customer = CreateObjectFromReader(reader);
                                return customer;
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

        public List<Customer> GetAll()
        {
            List<Customer> customers = new List<Customer>();
            if (OpenConnection())
            {
                string query = "select *, k.id as klantid from Klant k inner join dak d on d.id = k.DakId inner join Addres a on a.ID = k.AddresId";
                try
                {
                    using (SqlCommand command = new SqlCommand(query, Connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                customers.Add(CreateObjectFromReader(reader));
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
            return customers;
        } 

    }
}