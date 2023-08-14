using System.Data;
using System.Data.SqlClient;
using Dapper;
using ORM_Fundamentals_Dapper.Models;

namespace ORM_Fundamentals_Dapper
{
    public class DataFetching
    {
        private string _connectionString;

        public DataFetching(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Order> FetchOrdersByCriteria(int? year = null, int? month = null, OrderStatus? status = null, int? productId = null)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();

                string selectQuery = "spFetchOrders";

                var parameters = new
                {
                    Year = year,
                    Month = month,
                    Status = status?.ToString(),
                    ProductId = productId
                };

                return dbConnection.Query<Order>(selectQuery, parameters, commandType: CommandType.StoredProcedure).AsList();
            }
        }
    }
}
