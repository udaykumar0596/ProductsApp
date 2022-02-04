using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PCNationProductsApp.Models;

namespace PCNationProductsApp.EntityConfigurations
{
    public class ProductsEntityConfiguration : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.ToTable("products", "production");
            builder.Property(x => x.ProductId).HasColumnName("product_id");
            builder.Property(x => x.ProductName).HasColumnName("product_name");
            builder.Property(x => x.BrandId).HasColumnName("brand_id");
            builder.Property(x => x.CategoryId).HasColumnName("category_id");
            builder.Property(x => x.ModelYear).HasColumnName("model_year");
            builder.Property(x => x.ListPrice).HasColumnName("list_price");
            builder.HasKey(k => k.ProductId);
        }
    }    
    public class StocksEntityConfiguration : IEntityTypeConfiguration<Stocks>
    {
        public void Configure(EntityTypeBuilder<Stocks> builder)
        {
            builder.ToTable("stocks", "production");
            builder.Property(x => x.StoreId).HasColumnName("store_id");
            builder.Property(x => x.ProductId).HasColumnName("product_id");
            builder.Property(x => x.Quantity).HasColumnName("quantity");
            builder.HasKey(k => new { k.StoreId, k.ProductId });
        }
    }
    public class CategoriesEntityConfiguration : IEntityTypeConfiguration<Categories>
    {
        public void Configure(EntityTypeBuilder<Categories> builder)
        {
            builder.ToTable("categories", "production");
            builder.Property(x => x.CategoryId).HasColumnName("category_id");
            builder.Property(x => x.CategoryName).HasColumnName("category_name");
            builder.HasKey(k => k.CategoryId);
        }
    }
    public class BrandsEntityConfiguration : IEntityTypeConfiguration<Brands>
    {
        public void Configure(EntityTypeBuilder<Brands> builder)
        {
            builder.ToTable("brands", "production");
            builder.Property(x => x.BrandId).HasColumnName("brand_id");
            builder.Property(x => x.BrandName).HasColumnName("brand_name");
            builder.HasKey(k => k.BrandId);
        }
    }
}
