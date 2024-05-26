using Microsoft.Data.SqlClient;

namespace Storage.DataAccess
{
    public static class DBHelper
    {
        public static SqlConnection GetSqlConnection(string databaseName)
        {
            string connectionString = $"Data Source=DESKTOP-DBAC4GV\\SQLEXPRESS;Initial Catalog={databaseName};Integrated Security=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;TrustServerCertificate=True";

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }

            return sqlConnection;
        }
    }
}
