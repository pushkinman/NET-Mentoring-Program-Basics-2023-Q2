using ADO_NET_Solution.Interfaces;
using ADO_NET_Solution.Models;
using System.Data.SqlClient;

namespace ADO_NET_Solution
{
    public class ProductOperations
    {
        private IDatabaseConnectionProvider dbConnectionProvider;

        public ProductOperations(IDatabaseConnectionProvider connectionProvider)
        {
            dbConnectionProvider = connectionProvider;
        }

        public void CreateProduct(Product product)
        {
            using (var connection = dbConnectionProvider.GetConnection())
            {
                connection.Open();

                string insertQuery = "INSERT INTO Product (Name, Description, Weight, Height, Width, Length) " +
                                     "VALUES (@Name, @Description, @Weight, @Height, @Width, @Length)";

                using (SqlCommand command = new SqlCommand(insertQuery, (SqlConnection)connection))
                {
                    command.Parameters.AddWithValue("@Name", product.Name);
                    command.Parameters.AddWithValue("@Description", product.Description);
                    command.Parameters.AddWithValue("@Weight", product.Weight);
                    command.Parameters.AddWithValue("@Height", product.Height);
                    command.Parameters.AddWithValue("@Width", product.Width);
                    command.Parameters.AddWithValue("@Length", product.Length);

                    command.ExecuteNonQuery();
                }
            }
        }


        public Product ReadProduct(int productId)
        {
            using (var connection = dbConnectionProvider.GetConnection())
            {
                connection.Open();

                string selectQuery = "SELECT * FROM Product WHERE Id = @ProductId";

                using (SqlCommand command = new SqlCommand(selectQuery, (SqlConnection)connection))
                {
                    command.Parameters.AddWithValue("@ProductId", productId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
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
                            return product;
                        }
                    }
                }
            }

            return null;
        }

        public void UpdateProduct(Product product)
        {
            using (var connection = dbConnectionProvider.GetConnection())
            {
                connection.Open();

                string updateQuery = "UPDATE Product SET Name = @Name, Description = @Description, " +
                                     "Weight = @Weight, Height = @Height, Width = @Width, Length = @Length " +
                                     "WHERE Id = @ProductId";

                using (SqlCommand command = new SqlCommand(updateQuery, (SqlConnection)connection))
                {
                    command.Parameters.AddWithValue("@Name", product.Name);
                    command.Parameters.AddWithValue("@Description", product.Description);
                    command.Parameters.AddWithValue("@Weight", product.Weight);
                    command.Parameters.AddWithValue("@Height", product.Height);
                    command.Parameters.AddWithValue("@Width", product.Width);
                    command.Parameters.AddWithValue("@Length", product.Length);
                    command.Parameters.AddWithValue("@ProductId", product.Id);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteProduct(int productId)
        {
            using (var connection = dbConnectionProvider.GetConnection())
            {
                connection.Open();

                string deleteQuery = "DELETE FROM Product WHERE Id = @ProductId";

                using (SqlCommand command = new SqlCommand(deleteQuery, (SqlConnection)connection))
                {
                    command.Parameters.AddWithValue("@ProductId", productId);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
