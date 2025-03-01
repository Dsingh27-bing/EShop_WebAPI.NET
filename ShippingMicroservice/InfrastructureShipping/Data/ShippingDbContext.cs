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
    
    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<Shipper>()
    //         .HasMany(s => s.ShipperRegions)
    //         .WithOne(sr => sr.Shipper)
    //         .HasForeignKey(sr => sr.ShipperId);
    //     
    //     modelBuilder.Entity<Region>()
    //         .HasMany(r => r.ShipperRegions)
    //         .WithOne(sr => sr.Region)
    //         .HasForeignKey(sr => sr.RegionId);
    //     
    //     modelBuilder.Entity<ShippingDetails>()
    //         .HasOne(sd => sd.Shipper)
    //         .WithMany(s => s.ShippingDetails)
    //         .HasForeignKey(sd => sd.ShipperId);
    //     
    //     modelBuilder.Entity<ShippingDetails>()
    //         .HasOne(sd => sd.Region)
    //         .WithMany(r => r.ShippingDetails)
    //         .HasForeignKey(sd => sd.RegionId);
    // }
}