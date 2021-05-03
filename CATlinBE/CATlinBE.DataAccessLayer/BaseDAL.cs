using System.Data.SqlClient;

namespace CATlinBE.DataAccessLayer
{
    public class BaseDAL
    {
        public string ConnectionString { get; set; }

        public SqlConnection GetSqlConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        public SqlCommand GetSqlCommand(string SQL, SqlConnection conn)
        {
            return new SqlCommand(SQL, conn);
        }
    }
}
