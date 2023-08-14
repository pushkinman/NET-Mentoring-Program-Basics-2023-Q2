using System.Data;
using System.Data.SqlClient;
using Dapper;
using ORM_Fundamentals_Dapper.Models;

namespace ORM_Fundamentals_Dapper
{
    public class ProductOperations
    {
        private readonly string connectionString;

        public ProductOperations(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void CreateProduct(Product product)
        {
            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                string insertQuery = "INSERT INTO Product (Name, Description, Weight, Height, Width, Length) " +
                                     "VALUES (@Name, @Description, @Weight, @Height, @Width, @Length)";

                dbConnection.Execute(insertQuery, product);
            }
        }

        public Product ReadProduct(int productId)
        {
            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                string selectQuery = "SELECT * FROM Product WHERE Id = @ProductId";

                return dbConnection.QuerySingleOrDefault<Product>(selectQuery, new { ProductId = productId });
            }
        }

        public void UpdateProduct(Product product)
        {
            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                string updateQuery = "UPDATE Product SET Name = @Name, Description = @Description, " +
                                     "Weight = @Weight, Height = @Height, Width = @Width, Length = @Length " +
                                     "WHERE Id = @Id";

                dbConnection.Execute(updateQuery, product);
            }
        }

        public void DeleteProduct(int productId)
        {
            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                string deleteQuery = "DELETE FROM Product WHERE Id = @ProductId";

                dbConnection.Execute(deleteQuery, new { ProductId = productId });
            }
        }

        public List<Product> GetAllProducts()
        {
            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                string selectQuery = "SELECT * FROM Product";

                return dbConnection.Query<Product>(selectQuery).AsList();
            }
        }
    }
}
