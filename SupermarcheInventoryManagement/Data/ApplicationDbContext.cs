using Microsoft.EntityFrameworkCore;
using SupermarcheInventoryManagement.Models;
namespace SupermarcheInventoryManagement.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
    }
}
