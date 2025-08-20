using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;


namespace ProductCatalog.Util
{
   public static class DatabaseHelper
    {
        private static readonly string connectionString;

        // Static constructor loads config once
        static DatabaseHelper()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // looks in root
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            connectionString = config.GetConnectionString("DefaultConnection");
        }

        public static SqlConnection GetConnection()
        {
            var conn = new SqlConnection(connectionString);
            conn.Open();
            return conn;
        }
    }
}
