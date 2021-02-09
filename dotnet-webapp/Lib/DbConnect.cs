using System;
using System.Collections.Generic;
using MySqlConnector;

namespace dotnet.Lib
{
    public class DbConnect
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        public DbConnect()
        {
            Initialize();
        }

        private void Initialize()
        {
            server = "192.168.1.45";
            database = "mydb";
            uid = "jarvis";
            password = "root";
            string connectionString = "Server=" + server + ";" + "Database=" + 
                                        database + ";" + "Uid=" + uid + ";" + "Pwd=" + password + ";";
            try
            {
                connection = new MySqlConnection(connectionString);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            Console.WriteLine(connection);
        }

        public bool Ping()
        {
            return connection.Ping();
        }

    }
}