using Microsoft.EntityFrameworkCore;
using ReviewsApplicationCore.Entity;

namespace ReviewsInfrastructure.Data;

public class ReviewsDbContext:DbContext
{
    public ReviewsDbContext(DbContextOptions<ReviewsDbContext> options):base(options)
    {
        
    }
    
    public DbSet<Reviews> Reviews { get; set; }
    
    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<Reviews>()
    //         .HasOne(r => r.Product)
    //         .WithMany(p => p.Reviews)
    //         .HasForeignKey(r => r.ProductId);
    // }
    
}