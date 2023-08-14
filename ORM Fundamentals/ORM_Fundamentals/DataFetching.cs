using ORM_Fundamentals.Models;

namespace ORM_Fundamentals
{
    public class DataFetching
    {
        private ApplicationDbContext dbContext;

        public DataFetching(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public List<Order> FetchOrdersByCriteria(int? year = null, int? month = null, OrderStatus? status = null, int? productId = null)
        {
            var query = dbContext.Orders.AsQueryable();

            if (year.HasValue)
            {
                query = query.Where(o => o.CreateDate.Year == year);
            }

            if (month.HasValue)
            {
                query = query.Where(o => o.CreateDate.Month == month);
            }

            if (status.HasValue)
            {
                query = query.Where(o => o.Status == status);
            }

            if (productId.HasValue)
            {
                query = query.Where(o => o.ProductId == productId);
            }

            return query.ToList();
        }
    }
}
