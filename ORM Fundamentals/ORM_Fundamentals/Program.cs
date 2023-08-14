using Microsoft.Extensions.DependencyInjection;
using ORM_Fundamentals.Models;
using Microsoft.EntityFrameworkCore;

namespace ORM_Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ORM;Integrated Security=True;Connect Timeout=30;Encrypt=False";

            var serviceProvider = new ServiceCollection()
                .AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(connectionString))
                .BuildServiceProvider();

            using (var context = serviceProvider.GetService<ApplicationDbContext>())
            {
                var dataManipulation = new DataManipulation(context);
                var productOperations = new ProductOperations(context);

                dataManipulation.BulkDeleteOrdersUsingStoredProc(year: 2023, status: OrderStatus.Done);

                Console.WriteLine("Data manipulation completed.");

                var product1 = new Product
                {
                    Name = "Product 1",
                    Description = "Description 1",
                    Weight = 1,
                    Height = 10,
                    Width = 5,
                    Length = 8
                };

                var product2 = new Product
                {
                    Name = "Product 2",
                    Description = "Description 2",
                    Weight = 2,
                    Height = 12,
                    Width = 6,
                    Length = 9
                };

                productOperations.CreateProduct(product1);
                productOperations.CreateProduct(product2);
            }
        }
    }
}





