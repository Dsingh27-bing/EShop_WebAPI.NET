using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities;

public class ShoppingCartItem
{
    public int Id { get; set; }
    [ForeignKey("ShoppingCart")]
    public int? CartId { get; set; }
    public int? ProductId { get; set; }
    public String? ProductName { get; set; }
    public int? Qty { get; set; }
    public Decimal? Price { get; set; }
    
    public ShoppingCart? ShoppingCart { get; set; }
}