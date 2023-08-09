using ADO_NET_Solution.Interfaces;
using ADO_NET_Solution.Models;
using System.Data.SqlClient;

namespace ADO_NET_Solution
{
    public class OrderOperations
    {
        private IDatabaseConnectionProvider dbConnectionProvider;

        public OrderOperations(IDatabaseConnectionProvider connectionProvider)
        {
            dbConnectionProvider = connectionProvider;
        }

        public void CreateOrder(Order order)
        {
            using (var connection = dbConnectionProvider.GetConnection())
            {
                connection.Open();

                string insertQuery = "INSERT INTO [Order] (Status, CreateDate, UpdateDate, ProductId) " +
                                     "VALUES (@Status, @CreateDate, @UpdateDate, @ProductId)";

                using (SqlCommand command = new SqlCommand(insertQuery, (SqlConnection)connection))
                {
                    command.Parameters.AddWithValue("@Status", order.Status.ToString()); // Convert enum to string
                    command.Parameters.AddWithValue("@CreateDate", order.CreateDate);
                    command.Parameters.AddWithValue("@UpdateDate", order.UpdateDate);
                    command.Parameters.AddWithValue("@ProductId", order.ProductId);

                    command.ExecuteNonQuery();
                }
            }
        }

        public Order ReadOrder(int orderId)
        {
            using (var connection = dbConnectionProvider.GetConnection())
            {
                connection.Open();

                string selectQuery = "SELECT * FROM [Order] WHERE Id = @OrderId";

                using (SqlCommand command = new SqlCommand(selectQuery, (SqlConnection)connection))
                {
                    command.Parameters.AddWithValue("@OrderId", orderId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Order order = new Order
                            {
                                Id = (int)reader["Id"],
                                Status = Enum.Parse<OrderStatus>(reader["Status"].ToString()), // Convert string to enum
                                CreateDate = (DateTime)reader["CreateDate"],
                                UpdateDate = (DateTime)reader["UpdateDate"],
                                ProductId = (int)reader["ProductId"]
                            };
                            return order;
                        }
                    }
                }
            }
            
            return null; 
        }

        public void UpdateOrder(Order order)
        {
            using (var connection = dbConnectionProvider.GetConnection())
            {
                connection.Open();

                string updateQuery = "UPDATE [Order] SET Status = @Status, " +
                                     "UpdateDate = @UpdateDate, ProductId = @ProductId " +
                                     "WHERE Id = @OrderId";

                using (SqlCommand command = new SqlCommand(updateQuery, (SqlConnection)connection))
                {
                    command.Parameters.AddWithValue("@Status", order.Status.ToString()); // Convert enum to string
                    command.Parameters.AddWithValue("@UpdateDate", order.UpdateDate);
                    command.Parameters.AddWithValue("@ProductId", order.ProductId);
                    command.Parameters.AddWithValue("@OrderId", order.Id);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteOrder(int orderId)
        {
            using (var connection = dbConnectionProvider.GetConnection())
            {
                connection.Open();

                string deleteQuery = "DELETE FROM [Order] WHERE Id = @OrderId";

                using (SqlCommand command = new SqlCommand(deleteQuery, (SqlConnection)connection))
                {
                    command.Parameters.AddWithValue("@OrderId", orderId);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
