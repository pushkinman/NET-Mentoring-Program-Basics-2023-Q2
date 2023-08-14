using System.Data;
using System.Data.SqlClient;
using Dapper;
using ORM_Fundamentals_Dapper.Models;

namespace ORM_Fundamentals_Dapper
{
    public class DataManipulation
    {
        private string _connectionString;

        public DataManipulation(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void BulkDeleteOrdersUsingStoredProc(int? year = null, int? month = null, OrderStatus? status = null, int? productId = null)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();

                string deleteQuery = "spBulkDeleteOrders"; // Stored procedure name

                var parameters = new
                {
                    Year = year,
                    Month = month,
                    Status = status?.ToString(),
                    ProductId = productId
                };

                dbConnection.Execute(deleteQuery, parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
