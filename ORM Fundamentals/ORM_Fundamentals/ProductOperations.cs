using ORM_Fundamentals.Models;

namespace ORM_Fundamentals
{
    public class ProductOperations
    {
        private ApplicationDbContext dbContext;

        public ProductOperations(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public void CreateProduct(Product product)
        {
            dbContext.Products.Add(product);
            dbContext.SaveChanges();
        }

        public Product ReadProduct(int productId)
        {
            return dbContext.Products.FirstOrDefault(p => p.Id == productId);
        }

        public void UpdateProduct(Product product)
        {
            var existingProduct = dbContext.Products.Find(product.Id);
            if (existingProduct != null)
            {
                dbContext.Entry(existingProduct).CurrentValues.SetValues(product);
                dbContext.SaveChanges();
            }
        }

        public void DeleteProduct(int productId)
        {
            var product = dbContext.Products.Find(productId);
            if (product != null)
            {
                dbContext.Products.Remove(product);
                dbContext.SaveChanges();
            }
        }
    }
}
