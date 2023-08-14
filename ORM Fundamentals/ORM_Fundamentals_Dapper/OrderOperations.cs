using System.Data;
using System.Data.SqlClient;
using Dapper;
using ORM_Fundamentals_Dapper.Models;

namespace ORM_Fundamentals_Dapper
{
    public class OrderOperations
    {
        private readonly string connectionString;

        public OrderOperations(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void CreateOrder(Order order)
        {
            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                string insertQuery = "INSERT INTO [Order] (Status, CreateDate, UpdateDate, ProductId) " +
                                     "VALUES (@Status, @CreateDate, @UpdateDate, @ProductId)";

                dbConnection.Execute(insertQuery, order);
            }
        }

        public Order ReadOrder(int orderId)
        {
            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                string selectQuery = "SELECT * FROM [Order] WHERE Id = @OrderId";

                return dbConnection.QuerySingleOrDefault<Order>(selectQuery, new { OrderId = orderId });
            }
        }

        public void UpdateOrder(Order order)
        {
            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                string updateQuery = "UPDATE [Order] SET Status = @Status, UpdateDate = @UpdateDate, " +
                                     "ProductId = @ProductId WHERE Id = @Id";

                dbConnection.Execute(updateQuery, order);
            }
        }

        public void DeleteOrder(int orderId)
        {
            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                string deleteQuery = "DELETE FROM [Order] WHERE Id = @OrderId";

                dbConnection.Execute(deleteQuery, new { OrderId = orderId });
            }
        }

        public List<Order> GetAllOrders()
        {
            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                string selectQuery = "SELECT * FROM [Order]";

                return dbConnection.Query<Order>(selectQuery).AsList();
            }
        }
    }
}
