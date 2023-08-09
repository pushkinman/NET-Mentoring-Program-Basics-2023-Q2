using ADO_NET_Solution.Models;

namespace ADO_NET_Solution
{
    class Program
    {
        private static void Main(string[] args)
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            ProductOperations productOps = new ProductOperations(dbConnection);
            OrderOperations orderOps = new OrderOperations(dbConnection);
            DataFetching dataFetching = new DataFetching(dbConnection);
            DataManipulation dataManipulation = new DataManipulation(dbConnection);

            // Now you can call methods from the above classes to implement your application logic
            // For example:
            List<Product> products = dataFetching.FetchAllProducts();
            foreach (Product product in products)
            {
                Console.WriteLine($"Product: {product.Name}");
            }

            List<Order> orders = dataFetching.FetchOrdersByCriteria(status: OrderStatus.InProgress);
            foreach (Order order in orders)
            {
                Console.WriteLine($"Fetching Order: {order.Status}");
            }

            productOps.CreateProduct(new Product() { Name = "Car", Description = "Transport", Height = 1, Length = 1, Weight = 1, Width = 1, });
            var productValue = productOps.ReadProduct(3);
            Console.WriteLine(productValue.Name);

            orderOps.CreateOrder(new Order()
            {
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                ProductId = 3,
                Status = OrderStatus.InProgress
            });

            dataManipulation.BulkDeleteOrdersUsingStoredProc(status: OrderStatus.InProgress);

            // Test other methods similarly

            Console.ReadLine();
        }
    }
}