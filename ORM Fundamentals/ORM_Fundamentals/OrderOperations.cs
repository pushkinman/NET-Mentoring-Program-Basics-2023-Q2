using ORM_Fundamentals.Models;

namespace ORM_Fundamentals
{
    public class OrderOperations
    {
        private ApplicationDbContext dbContext;

        public OrderOperations(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public void CreateOrder(Order order)
        {
            dbContext.Orders.Add(order);
            dbContext.SaveChanges();
        }

        public Order ReadOrder(int orderId)
        {
            return dbContext.Orders.FirstOrDefault(o => o.Id == orderId);
        }

        public void UpdateOrder(Order order)
        {
            var existingOrder = dbContext.Orders.Find(order.Id);
            if (existingOrder != null)
            {
                dbContext.Entry(existingOrder).CurrentValues.SetValues(order);
                dbContext.SaveChanges();
            }
        }

        public void DeleteOrder(int orderId)
        {
            var order = dbContext.Orders.Find(orderId);
            if (order != null)
            {
                dbContext.Orders.Remove(order);
                dbContext.SaveChanges();
            }
        }
    }
}
