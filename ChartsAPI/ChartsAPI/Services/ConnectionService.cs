using ChartsAPI.Models;

namespace ChartsAPI.Services
{
    public class ConnectionService
    {
        private Connection _connection;

        public ConnectionService()
        {
            
            _connection = new Connection
            {
                ServerName = "DefaultServer",
                DatabaseName = "DefaultDB",
                TrustedConnection = true
            };
        }

        // Connection bilgilerini döndürme kısmını buraya ekledim
        public Connection GetConnection()
        {
            return _connection;
        }

        // Connection bilgilerini güncelleme bu fonksiyon ile yapılıyor
        public void UpdateConnection(string serverName, string databaseName, bool trustedConnection)
        {
            _connection.ServerName = serverName;
            _connection.DatabaseName = databaseName;
            _connection.TrustedConnection = trustedConnection;
        }
    }
}
