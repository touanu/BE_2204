using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace StudentManager.DataAccess
{
    public static class DBHelper
    {
        public static SqlConnection GetSqlConnection()
        {
            string connectionString = "Data Source=DESKTOP-DBAC4GV\\SQLEXPRESS;Initial Catalog=StudentDB;Integrated Security=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;TrustServerCertificate=True";

            SqlConnection sqlConnection = new(connectionString);

            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }

            return sqlConnection;
        }
    }
}
