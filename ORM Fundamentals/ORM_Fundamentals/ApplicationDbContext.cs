using Microsoft.EntityFrameworkCore;
using ORM_Fundamentals.Models;

namespace ORM_Fundamentals
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
