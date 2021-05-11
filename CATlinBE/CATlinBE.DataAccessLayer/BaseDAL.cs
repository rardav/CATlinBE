using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace CATlinBE.DataAccessLayer
{
    public class BaseDAL
    {
        private string _connectionString;

        public BaseDAL()
        {
             var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            _connectionString = builder.Build().GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
        }

        public SqlConnection GetSqlConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public SqlCommand GetSqlCommand(string SQL, SqlConnection conn)
        {
            return new SqlCommand(SQL, conn);
        }
    }
}
