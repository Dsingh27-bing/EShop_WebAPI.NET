using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities;

public class Customer
{
    public int Id { get; set; }
    [MaxLength(50)]
    public String? FirstName { get; set; }
    [MaxLength(50)]
    public String? LastName { get; set; }
    [MaxLength(20)]
    public String? Gender { get; set; }
    public int? Phone { get; set; }
    [MaxLength(350)]
    public String? ProfilePic { get; set; }
    public int? UserId { get; set; }
    
    public IEnumerable<UserAddress> UserAddresses { get; set; } = new List<UserAddress>();
    public IEnumerable<Order> Orders { get; set; } = new List<Order>();
    public IEnumerable<ShoppingCart> ShoppingCarts { get; set; } = new List<ShoppingCart>();
    public IEnumerable<PaymentMethod> PaymentMethods { get; set; } = new List<PaymentMethod>();
    
}