using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using EcoRP.IRepository;
using EcoRP.Models;

namespace EcoRP.Repositories.MSSQLRepository
{
    public class MSSQLInverterRepository:Database,IInverterRepository
    {
        private Inverter CreateFromReader(SqlDataReader reader)
        {
            string Name = reader["Naam"].ToString();
            string Brand = reader["Merk"].ToString();
            string Description = reader["Omschrijving"].ToString();
            int Warranty = Convert.ToInt32(reader["Garantie"]);
            int Power = Convert.ToInt32(reader["Vermogen"]);
            string Color = Convert.ToString(reader["kleur"]);
            int Length = Convert.ToInt32(reader["lengte"]);
            int Width = Convert.ToInt32(reader["Breedte"]);
            int Id = Convert.ToInt32(reader["Id"]);
            bool Monitoring = Convert.ToBoolean(reader["Monitoring"]);
            int Serial = Convert.ToInt32(reader["Serienummer"]);
            int Height = Convert.ToInt32(reader["Hoogte"]);
            int Stock = Convert.ToInt32(reader["Voorraad"]);
            decimal Price = Convert.ToDecimal(reader["Prijs"]);
            Inverter inverter = new Inverter(Id, Name, Serial, Stock, Brand, Description, Warranty, Power, Length, Color,Monitoring, Price, Width, Height);
            return inverter;
        }
        public void Insert(Inverter entity)
        {
            if (OpenConnection())
            {
                try
                {
                    SqlConnection Connection = this.Connection;
                    SqlCommand command = Connection.CreateCommand();
                    command.CommandText = "EXECUTE insertInverter @Naam,@Merk,@Omschrijving,@Garantie,@Vermogen,@Monitoring,@lengte,@Breedte,@Hoogte,@Serienummer,@Prijs,@Kleur";
                    command.Parameters.AddWithValue("@Naam", entity.Name);
                    command.Parameters.AddWithValue("@Merk", entity.Brand);
                    command.Parameters.AddWithValue("@Omschrijving", entity.Description);
                    command.Parameters.AddWithValue("@Garantie", entity.Warranty);
                    command.Parameters.AddWithValue("@Vermogen", entity.Power);
                    command.Parameters.AddWithValue("@Monitoring", Convert.ToInt32(entity.Monitoring));
                    command.Parameters.AddWithValue("@lengte", entity.Length);
                    command.Parameters.AddWithValue("@Breedte", entity.Width);
                    command.Parameters.AddWithValue("@Hoogte", entity.Height);
                    command.Parameters.AddWithValue("@Serienummer", entity.Serial);
                    command.Parameters.AddWithValue("@Prijs", entity.Price);
                    command.Parameters.AddWithValue("@Kleur", entity.Color);

                    command.ExecuteNonQuery();

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

        public void Update(int id, Inverter entity)
        {
            if (OpenConnection())
            {
                try
                {
                    SqlConnection Connection = this.Connection;
                    SqlCommand command = Connection.CreateCommand();
                    command.CommandText = "EXECUTE updateInverter @Naam,@Merk,@Omschrijving,@Garantie,@Vermogen,@Monitoring,@lengte,@Breedte,@Hoogte,@Serienummer,@Prijs,@Kleur,@ProductId";
                    command.Parameters.AddWithValue("@Naam", entity.Name);
                    command.Parameters.AddWithValue("@Merk", entity.Brand);
                    command.Parameters.AddWithValue("@Omschrijving", entity.Description);
                    command.Parameters.AddWithValue("@Garantie", entity.Warranty);
                    command.Parameters.AddWithValue("@Vermogen", entity.Power);
                    command.Parameters.AddWithValue("@Monitoring", Convert.ToInt32(entity.Monitoring));
                    command.Parameters.AddWithValue("@lengte", entity.Length);
                    command.Parameters.AddWithValue("@Breedte", entity.Width);
                    command.Parameters.AddWithValue("@Hoogte", entity.Height);
                    command.Parameters.AddWithValue("@Serienummer", entity.Serial);
                    command.Parameters.AddWithValue("@Prijs", entity.Price);
                    command.Parameters.AddWithValue("@Kleur", entity.Color);
                    command.Parameters.AddWithValue("@ProductId", entity.Id);

                    command.ExecuteNonQuery();

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
                try
                {
                    SqlConnection Connection = this.Connection;
                    SqlCommand command = Connection.CreateCommand();
                    command.CommandText = "EXECUTE deleteProduct @Id";
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();

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

        public Inverter GetById(int id)
        {
            string query = "select p.Id,Serienummer,Naam,Prijs,Merk,Omschrijving,Garantie,Voorraad,kleur,lengte,breedte,hoogte,monitoring,vermogen from Product p inner join ProductEigenschappen pe on pe.Id = p.EigenschappenID where TypeID = 2 and p.id = @id";
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
                                Inverter inverter = CreateFromReader(reader);
                                return inverter;
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
            throw new Exception();
        }

        public List<Inverter> GetAll()
        {
            List<Inverter> Inverters = new List<Inverter>();
            string query ="select p.Id,Serienummer,Naam,Prijs,Merk,Omschrijving,Garantie,Voorraad,kleur,lengte,breedte,hoogte,monitoring,vermogen from Product p inner join ProductEigenschappen pe on pe.Id = p.EigenschappenID where TypeID = 2";
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
                                Inverters.Add(CreateFromReader(reader));
                            }
                            return Inverters;
                        }
                    }
                }
                catch (SqlException exception)
                {
                    throw exception;
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