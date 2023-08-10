using ADO_NET_Solution.Interfaces;
using ADO_NET_Solution.Models;
using Moq;
using NUnit.Framework;
using System.Data.SqlClient;

namespace ADO_NET_Solution.Tests
{
    [TestFixture]
    public class ProductOperationsTests
    {
        private readonly Mock<OperationsBase> _productOperations = new Mock<OperationsBase>();
        private readonly Mock<IDatabaseConnectionProvider> _databaseConnectionProvider = new Mock<IDatabaseConnectionProvider>();
        

        [Test]
        public void ReadProduct_ShouldReturnProduct_WhenProductExist()
        {
            var productId = 1;
            var product = new Product()
            {
                Id = productId,
                Description = "Description",
                Name = "Name",
                Height = 200,
                Length = 200,
                Weight = 200,
                Width = 200,
            };

            _productOperations.Setup(x => x.ReadProduct(productId)).Returns(product);

            var reviecedProduct = _productOperations.Object.ReadProduct(productId);

            Assert.AreEqual(productId, reviecedProduct.Id);
        }
    }
}
