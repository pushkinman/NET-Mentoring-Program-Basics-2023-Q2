using ORM_Fundamentals_Dapper.Models;

namespace ORM_Fundamentals_Dapper
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ORM;Integrated Security=True;Connect Timeout=30;Encrypt=False";

            var orderOperations = new OrderOperations(connectionString);
            var productOperations = new ProductOperations(connectionString);

            Product newProduct = new Product
            {
                Name = "Sample Product",
                Description = "A sample product",
                Weight = 1,
                Height = 10,
                Width = 5,
                Length = 15
            };
            productOperations.CreateProduct(newProduct);

            Order newOrder = new Order
            {
                Status = OrderStatus.InProgress,
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                ProductId = 1
            };
            orderOperations.CreateOrder(newOrder);

            var orders = orderOperations.GetAllOrders();
            foreach (var order in orders)
            {
                Console.WriteLine($"Order ID: {order.Id}, Status: {order.Status}, Create Date: {order.CreateDate}");
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}