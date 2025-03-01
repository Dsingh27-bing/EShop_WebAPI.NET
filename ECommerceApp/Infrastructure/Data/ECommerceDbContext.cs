using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ECommerceDbContext:DbContext
{
    public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options ):base(options)
    {
    }
    
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetails> OrderDetails { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<UserAddress> UserAddresses { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    public DbSet<PaymentType> PaymentTypes { get; set; }
    public DbSet<PaymentMethod> PaymentMethods { get; set; }
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>()
            .HasMany(o => o.OrderDetails)
            .WithOne(od => od.Order)
            .HasForeignKey(od => od.OrderId);

        modelBuilder.Entity<Customer>()
            .HasMany(c => c.Orders)
            .WithOne(o => o.Customer)
            .HasForeignKey(o => o.CustomerId);

        modelBuilder.Entity<Customer>()
            .HasMany(c => c.UserAddresses)
            .WithOne(ua => ua.Customer)
            .HasForeignKey(ua => ua.CustomerId);

        modelBuilder.Entity<UserAddress>()
            .HasOne(ua => ua.Address)
            .WithMany(a => a.UserAddresses)
            .HasForeignKey(ua => ua.AddressId);
        
        modelBuilder.Entity<ShoppingCart>()
            .HasMany(sc => sc.ShoppingCartItems)
            .WithOne(sci => sci.ShoppingCart)
            .HasForeignKey(sci => sci.CartId);
        
        modelBuilder.Entity<PaymentType>()
            .HasMany(pt => pt.PaymentMethods)
            .WithOne(pm => pm.PaymentType)
            .HasForeignKey(pm => pm.PaymentTypeId);
        
        modelBuilder.Entity<ShoppingCart>()
            .HasOne(c => c.Customer)
            .WithMany(c => c.ShoppingCarts)
            .HasForeignKey(c => c.CustomerId);



    }
    
    
    
    
}
