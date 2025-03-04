using Microsoft.EntityFrameworkCore;
using ProductApplicationCore.Entities;

namespace ProductInfrastructure.Data;

public class ProductDbContext:DbContext
{
    public ProductDbContext(DbContextOptions<ProductDbContext> options ):base(options)
    {
    }
    
    public DbSet<ProductCategory> ProductCategory { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductVariationValues> ProductVariationsValues { get; set; }
    public DbSet<CategoryVariation> CategoryVariations { get; set; }
    public DbSet<VariationValue> VariationValues { get; set; }
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .HasOne(p => p.ProductCategory)
            .WithMany()
            .HasForeignKey(p => p.CategoryId);
        
        modelBuilder.Entity<ProductCategory>()
            .HasOne(pc => pc.ParentCategory)
            .WithMany(pc => pc.ChildCategories)
            .HasForeignKey(pc => pc.ParentCategoryId);
        
        modelBuilder.Entity<CategoryVariation>()
            .HasOne(cv => cv.ProductCategory)
            .WithMany()
            .HasForeignKey(cv => cv.CategoryId);

        modelBuilder.Entity<ProductVariationValues>().HasKey(pv => new { pv.ProductId, pv.VariationValueId });
        modelBuilder.Entity<ProductVariationValues>()
            .HasOne(pv => pv.VariationValue)
            .WithMany()
            .HasForeignKey(pv => pv.VariationValueId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ProductVariationValues>()
            .HasOne(pv => pv.Product)
            .WithMany()
            .HasForeignKey(pv => pv.ProductId);

        modelBuilder.Entity<VariationValue>()
            .HasOne(v => v.CategoryVariation)
            .WithMany()
            .HasForeignKey(v => v.VariationId);
        
    }
}