using ADO_NET_Solution.Interfaces;
using ADO_NET_Solution.Models;
using Moq;
using System.Data;
using System.Data.SqlClient;

namespace ADO_NET_Solution.Testing
{
    [TestFixture]
    public class ProductOperationsTests
    {
        [Test]
        public void TestCreateProduct()
        {
            // Arrange
            var connectionFactory = new ConnectionFactory();
            var productOps = new ProductOperations(connectionFactory);

            var product = new Product
            {
                Id = 1,
                Name = "Sample Product",
                Description = "Test description",
                Weight = 2.5M,
                Height = 10.0M,
                Width = 5.0M,
                Length = 15.0M
            };

            // Act
            productOps.CreateProduct(product);

            // Assert
            using (var connection = new SqlConnection("Data Source=(localdb)\\\\MSSQLLocalDB;Initial Catalog=ADO_DB;Integrated Security=True;Connect Timeout=30;Encrypt=False;"))
            {
                connection.Open();

                string selectQuery = "SELECT COUNT(*) FROM Product WHERE Id = @ProductId";

                using (var command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@ProductId", product.Id);
                    int count = (int)command.ExecuteScalar();
                    Assert.AreEqual(1, count); // Check that the product was actually inserted
                }
            }
        }
    }
}
