using _15_ServiceLayer_Practice_Product.Models;
using Microsoft.EntityFrameworkCore;

namespace _15_ServiceLayer_Practice_Product.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .IsRequired();

            modelBuilder.Entity<Product>()
               .Property(p => p.Price)
               .HasColumnType("decimal(18,2)");

            base.OnModelCreating(modelBuilder);
        }
    }
}
