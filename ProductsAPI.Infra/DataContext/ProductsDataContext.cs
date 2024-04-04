using Microsoft.EntityFrameworkCore;
using ProductsAPI.Domain.Entities;

namespace ProductsAPI.Infra.DataContext
{
    public class ProductsDataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=Products;User Id=sa;Password=123456;TrustServerCertificate=true;");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
    }
}
