using ApplicationCoreShipping.Entities;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureShipping.Data;

public class ShippingDbContext:DbContext
{
    public ShippingDbContext(DbContextOptions<ShippingDbContext> options ):base(options)
    {
    }
    
    public DbSet<Shipper> Shippers { get; set; }
    public DbSet<ShipperRegion> ShipperRegions { get; set; }
    public DbSet<ShippingDetails> ShippingDetails{ get; set; }
    public DbSet<Region> Regions { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShipperRegion>().HasKey(sr => new { sr.ShipperId, sr.RegionId });

            base.OnModelCreating(modelBuilder);
        }
}