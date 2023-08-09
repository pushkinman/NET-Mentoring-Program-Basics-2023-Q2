using ADO_NET_Solution.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace ADO_NET_Solution
{
    public class DatabaseConnection : IDatabaseConnectionProvider
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ADO_DB;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

        public IDbConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
