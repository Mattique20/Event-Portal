using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Database_Handler
{
    public class DatabaseHandler
    {
        private static string connection;
        private static DatabaseHandler instance;

        private DatabaseHandler() 
        {
            connection=Connection.GetInstance().ConnectionString;
        }

        public static DatabaseHandler getInstance()
        {
            if (instance == null)
                instance = new DatabaseHandler();
            return instance;
        }
    }
}