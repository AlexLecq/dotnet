using System;
using System.Collections.Generic;
using MySqlConnector;

namespace dotnet.Lib
{
    public class DbConnect
    {
        private MySqlConnection _connection;
        private readonly string server;
        private readonly string database;
        private readonly string uid;
        private readonly string password;
        private readonly string connectionString;

        public DbConnect()
        {
            server = "192.168.1.45";
            database = "mydb";
            uid = "jarvis";
            password = "root";
            connectionString = "server=" + server + ";" + "database=" + database + ";" + "user=" + uid + ";" + "password=" + password + ";";
            _connection = new MySqlConnection(connectionString);
        }

        public List<object> GetData()
        {
            string sql = "SELECT * FROM mytable";
            List<object> result = new List<object>();
            try
            {
                _connection.Open();
                MySqlCommand cmd = new MySqlCommand(sql, _connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(reader[0]);
                }
                
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return result;
        }
    }
}