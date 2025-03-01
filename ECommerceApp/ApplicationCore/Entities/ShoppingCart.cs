using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities;

public class ShoppingCart
{
    public int Id { get; set; }
    public int? CustomerId { get; set; }
    [MaxLength(100)]
    public string? CustomerName { get; set; }
    
    public IEnumerable<ShoppingCartItem> ShoppingCartItems { get; set; }
    public Customer? Customer { get; set; }
}