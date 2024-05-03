using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Database_Handler
{
    public class Connection
    {
        private static Connection instance;
        private string connectionString;
        private Connection()
        {
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["databaseConnection"].ConnectionString;

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Database Connection String is missing or empty.");
            }
        }

        public static Connection GetInstance()
        {
            if (instance == null) 
            {
                instance = new Connection();
            }

            return instance;
        }

        public string ConnectionString
        {
            get { return connectionString; }
        }
    }
}