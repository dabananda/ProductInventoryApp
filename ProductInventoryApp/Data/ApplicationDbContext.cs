using Microsoft.EntityFrameworkCore;
using ProductInventoryApp.Models;

namespace ProductInventoryApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Product> Products { get; set; }
    }
}
