using Microsoft.EntityFrameworkCore;
using PCNationProductsApp.EntityConfigurations;
using PCNationProductsApp.Models;

namespace PCNationProductsApp.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        public DbSet<Products> Products { get; set; }
        public DbSet<Stocks> Stocks { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Brands> Brands { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductsEntityConfiguration());
            modelBuilder.ApplyConfiguration(new BrandsEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CategoriesEntityConfiguration());
            modelBuilder.ApplyConfiguration(new StocksEntityConfiguration());
           
        }
    }
}
