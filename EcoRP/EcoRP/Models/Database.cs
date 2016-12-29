using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EcoRP.Models
{
    public abstract class Database
    {
        public string Server;
        public string DB;
        public string Uid;
        public string Password;
        public SqlConnection Connection;

        /// <summary>
        /// Opens a connection to the database
        /// </summary>
        /// <returns>true on success false on failure</returns>
        public bool OpenConnection()
        {
            Server = "mssql.fhict.local";
            DB = "dbi339814";
            Uid = "dbi339814";
            Password = "Denia123";
            string connectionString;
            connectionString = "SERVER=" + Server + ";" + "DATABASE=" +
            DB + ";" + "UID=" + Uid + ";" + "PASSWORD=" + Password + ";";

            Connection = new SqlConnection(connectionString);

            try
            {
                Connection.Open();
                return true;
            }
            catch (SqlException)
            {
                return false;
            }
        }
        /// <summary>
        /// Closes a connection to the database 
        /// </summary>
        /// <returns>true on success false on failure</returns>
        public bool CloseConnection()
        {
            try
            {
                Connection.Close();
                return true;
            }
            catch (SqlException)
            {
                return false;
            }
        }
    }
}