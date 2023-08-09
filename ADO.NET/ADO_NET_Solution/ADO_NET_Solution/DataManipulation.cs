using ADO_NET_Solution.Models;
using System.Data;
using System.Data.SqlClient;

namespace ADO_NET_Solution
{
    public class DataManipulation
    {
        private DatabaseConnection dbConnection;

        public DataManipulation(DatabaseConnection connection)
        {
            dbConnection = connection;
        }

        public void BulkDeleteOrdersUsingStoredProc(int? year = null, int? month = null, OrderStatus? status = null, int? productId = null)
        {
            using (var connection = dbConnection.GetConnection())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("spBulkDeleteOrders", (SqlConnection)connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    if (year.HasValue)
                    {
                        command.Parameters.AddWithValue("@Year", year.Value);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@Year", DBNull.Value);
                    }

                    if (month.HasValue)
                    {
                        command.Parameters.AddWithValue("@Month", month.Value);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@Month", DBNull.Value);
                    }

                    if (status.HasValue)
                    {
                        command.Parameters.AddWithValue("@Status", status.Value.ToString()); // Convert enum to string
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@Status", DBNull.Value);
                    }

                    if (productId.HasValue)
                    {
                        command.Parameters.AddWithValue("@ProductId", productId.Value);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@ProductId", DBNull.Value);
                    }

                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
