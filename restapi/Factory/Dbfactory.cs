using MySql.Data.MySqlClient;
using System;

namespace restapi.Factories
{
    public class Dbfactory
    {
        private static MySqlConnection _currentConnection;
        // private static PropertiesFactory _propertiesFactory = new();
        public static string ConnectionString { get; set; }
        
        public MySqlConnection GetConnection()
        {
            if (_currentConnection == null)
            {
                //_propertiesFactory ??= new PropertiesFactory();
                //ConnectionString = _propertiesFactory.BuildConnectionString();
                ConnectionString = @"server=myskyl;port=3306;database=comments;userid=root;password=password;";
                var newConnection = new MySqlConnection(ConnectionString);
                _currentConnection = newConnection;
                return _currentConnection;
            }

            return _currentConnection;
        }
        
    }
}


