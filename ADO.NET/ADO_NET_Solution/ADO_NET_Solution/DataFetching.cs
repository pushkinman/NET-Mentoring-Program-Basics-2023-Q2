using ADO_NET_Solution.Models;
using System.Data;
using System.Data.SqlClient;

namespace ADO_NET_Solution
{
    public class DataFetching
    {
        private DatabaseConnection dbConnection;

        public DataFetching(DatabaseConnection connection)
        {
            dbConnection = connection;
        }

        public List<Product> FetchAllProducts()
        {
            List<Product> products = new List<Product>();

            using (var connection = dbConnection.GetConnection())
            {
                connection.Open();

                string selectQuery = "SELECT * FROM Product";

                using (SqlCommand command = new SqlCommand(selectQuery, (SqlConnection)connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Product product = new Product
                            {
                                Id = (int)reader["Id"],
                                Name = reader["Name"].ToString(),
                                Description = reader["Description"].ToString(),
                                Weight = (decimal)reader["Weight"],
                                Height = (decimal)reader["Height"],
                                Width = (decimal)reader["Width"],
                                Length = (decimal)reader["Length"]
                            };
                            products.Add(product);
                        }
                    }
                }
            }

            return products;
        }

        public List<Order> FetchOrdersByCriteria(int? year = null, int? month = null, OrderStatus? status = null, int? productId = null)
        {
            List<Order> orders = new List<Order>();

            using (var connection = dbConnection.GetConnection())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("spFetchOrders", (SqlConnection)connection))
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

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Order order = new Order
                            {
                                Id = (int)reader["Id"],
                                Status = Enum.Parse<OrderStatus>(reader["Status"].ToString()), // Convert string to enum
                                CreateDate = (DateTime)reader["CreateDate"],
                                UpdateDate = (DateTime)reader["UpdateDate"],
                                ProductId = (int)reader["ProductId"]
                            };
                            orders.Add(order);
                        }
                    }
                }
            }

            return orders;
        }

    }
}
