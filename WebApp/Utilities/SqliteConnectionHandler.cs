using System;
using Microsoft.Data.Sqlite;

namespace WebApp.Utilities
{
    public class SqliteConnectionHandler
    {
        public static SqliteConnection Connect()
        {
            var connection = new SqliteConnection("Data Source=Resources/inventory_plus.db");
            return connection;
        }
    }
}

