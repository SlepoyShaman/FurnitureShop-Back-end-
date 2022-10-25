using FurnitureShop.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace Shop.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Chairs" },
                new Category { Id = 2, Name = "Beds" });
            modelBuilder.Entity<Company>().HasData(
                new Company { Id = 1, Name = "Ikea"},
                new Company { Id = 2, Name = "Amado"});
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Modern Chair", Price = 180, Img = "1.jpg", CategoryId = 1, CompanyId = 1 },
                new Product { Id = 2, Name = "Minimalistic Plant Pot", Price = 180, Img = "2.jpg", CategoryId = 2, CompanyId = 1 },
                new Product { Id = 3, Name = "Modern Chair", Price = 180, Img = "3.jpg", CategoryId = 1, CompanyId = 1 },
                new Product { Id = 4, Name = "Night Stand", Price = 100, Img = "4.jpg", CategoryId = 2, CompanyId = 1 },
                new Product { Id = 5, Name = "Plant Po", Price = 18, Img = "5.jpg", CategoryId = 1, CompanyId = 1 },
                new Product { Id = 6, Name = "Small Table", Price = 320, Img = "6.jpg", CategoryId = 2, CompanyId = 1 },
                new Product { Id = 7, Name = "Metallic Chair", Price = 318, Img = "7.jpg", CategoryId = 1, CompanyId = 2 },
                new Product { Id = 8, Name = "Modern Rocking Chair", Price = 318, Img = "8.jpg", CategoryId = 2, CompanyId = 2 },
                new Product { Id = 9, Name = "Home Deco", Price = 318, Img = "9.jpg", CategoryId = 1, CompanyId = 2 });
        }
    }
}

