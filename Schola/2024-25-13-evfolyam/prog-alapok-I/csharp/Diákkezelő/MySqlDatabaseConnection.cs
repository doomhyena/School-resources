using System;
using MySql.Data.MySqlClient;

namespace Diákkezelõ
{
    public class MySqlDatabaseConnection : IDisposable
    {
        private MySqlConnection _connection;

        public MySqlDatabaseConnection(string connectionString)
        {
            _connection = new MySqlConnection(connectionString);
            _connection.Open();
        }

        public MySqlConnection Connection => _connection;

        public void Dispose()
        {
            if (_connection != null)
            {
                if (_connection.State != System.Data.ConnectionState.Closed)
                    _connection.Close();
                _connection.Dispose();
                _connection = null;
            }
        }
    }
}
