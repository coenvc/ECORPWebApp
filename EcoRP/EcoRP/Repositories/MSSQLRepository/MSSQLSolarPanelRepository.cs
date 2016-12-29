using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using EcoRP.Enums;
using EcoRP.IRepository;
using EcoRP.Models;

namespace EcoRP.Repositories.MSSQLRepository
{
    public class MSSQLSolarPanelRepository:Database,ISolarpanelRepository
    {
        private SolarPanel CreateFromReader(SqlDataReader reader)
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
            string CelType = Convert.ToString(reader["Celtype"]);
            int Serial = Convert.ToInt32(reader["Serienummer"]);
            int Height = Convert.ToInt32(reader["Hoogte"]);
            int Stock = Convert.ToInt32(reader["Voorraad"]);
            decimal Price = Convert.ToDecimal(reader["Prijs"]);
            CelType CelTypeEnum = (CelType)Enum.Parse(typeof(CelType), CelType, true);
            SolarPanel solarPanel = new SolarPanel(Id,Name,Serial,Stock,Brand,Description,Warranty,Power, CelTypeEnum, Color,Length,Width,Height,Price);
            return solarPanel; 
        }
        public void Insert(SolarPanel entity)
        { 

            if (OpenConnection())
            {
                try
                {
                    SqlConnection Connection = this.Connection;
                    SqlCommand insertSolarPanel = Connection.CreateCommand();
                    insertSolarPanel.CommandText = "EXECUTE updateSolarPanel @Naam,@Merk,@Omschrijving,@Garantie,@Vermogen,@Celtype,@lengte,@Breedte,@Hoogte,@Serienummer,@Prijs,@Kleur";
                    insertSolarPanel.Parameters.AddWithValue("@Naam", entity.Name);
                    insertSolarPanel.Parameters.AddWithValue("@Merk", entity.Brand);
                    insertSolarPanel.Parameters.AddWithValue("@Omschrijving", entity.Description);
                    insertSolarPanel.Parameters.AddWithValue("@Garantie", entity.Warranty);
                    insertSolarPanel.Parameters.AddWithValue("@Vermogen", entity.Power);
                    insertSolarPanel.Parameters.AddWithValue("@Celtype", entity.Celtype);
                    insertSolarPanel.Parameters.AddWithValue("@lengte", entity.Length);
                    insertSolarPanel.Parameters.AddWithValue("@Breedte", entity.Width);
                    insertSolarPanel.Parameters.AddWithValue("@Hoogte", entity.Height);
                    insertSolarPanel.Parameters.AddWithValue("@Serienummer", entity.Serial);
                    insertSolarPanel.Parameters.AddWithValue("@Prijs", entity.Price);
                    insertSolarPanel.Parameters.AddWithValue("@Kleur", entity.Color);
   
                    insertSolarPanel.ExecuteNonQuery();

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

        public void Update(int id, SolarPanel entity)
        {

            if (OpenConnection())
            {
                try
                {
                    SqlConnection Connection = this.Connection;
                    SqlCommand insertSolarPanel = Connection.CreateCommand();
                    insertSolarPanel.CommandText = "EXECUTE insertSolarpanel @Naam,@Merk,@Omschrijving,@Garantie,@Vermogen,@Celtype,@lengte,@Breedte,@Hoogte,@Serienummer,@Prijs,@Kleur,@ProductId";
                    insertSolarPanel.Parameters.AddWithValue("@Naam", entity.Name);
                    insertSolarPanel.Parameters.AddWithValue("@Merk", entity.Brand);
                    insertSolarPanel.Parameters.AddWithValue("@Omschrijving", entity.Description);
                    insertSolarPanel.Parameters.AddWithValue("@Garantie", entity.Warranty);
                    insertSolarPanel.Parameters.AddWithValue("@Vermogen", entity.Power);
                    insertSolarPanel.Parameters.AddWithValue("@Celtype", entity.Celtype);
                    insertSolarPanel.Parameters.AddWithValue("@lengte", entity.Length);
                    insertSolarPanel.Parameters.AddWithValue("@Breedte", entity.Width);
                    insertSolarPanel.Parameters.AddWithValue("@Hoogte", entity.Height);
                    insertSolarPanel.Parameters.AddWithValue("@Serienummer", entity.Serial);
                    insertSolarPanel.Parameters.AddWithValue("@Prijs", entity.Price);
                    insertSolarPanel.Parameters.AddWithValue("@Kleur", entity.Color);
                    insertSolarPanel.Parameters.AddWithValue("@ProductId", entity.Id);
                    insertSolarPanel.ExecuteNonQuery();

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
                    SqlCommand insertSolarPanel = Connection.CreateCommand();
                    insertSolarPanel.CommandText = "EXECUTE deleteProduct @Id";
                    insertSolarPanel.Parameters.AddWithValue("@id",id);
                    insertSolarPanel.ExecuteNonQuery();

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

        public SolarPanel GetById(int id)
        {
            string query = "select p.ID,Naam,Serienummer,Prijs,Merk,Omschrijving,Garantie,vermogen,kleur,celtype,lengte,breedte,hoogte,voorraad from Product p inner join ProductEigenschappen pe on pe.Id = p.EigenschappenID where TypeID = 1 and p.id = @id";
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
                                SolarPanel solarpanel = CreateFromReader(reader);
                                return solarpanel;
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

        public List<SolarPanel> GetAll()
        {
            List<SolarPanel> solarPanels = new List<SolarPanel>();
            string query = "select p.ID,Naam,Serienummer,Prijs,Merk,Omschrijving,Garantie,vermogen,kleur,celtype,lengte,breedte,hoogte,voorraad from Product p inner join ProductEigenschappen pe on pe.Id = p.EigenschappenID where TypeID = 1";
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
                                solarPanels.Add(CreateFromReader(reader));
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
            return solarPanels;
        }
        } 

        
    }
