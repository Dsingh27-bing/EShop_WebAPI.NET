using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities;

public class OrderDetails
{
    public int Id { get; set; }
    [Required]
    public int OrderId { get; set; }
    [Required]
    public int ProductId { get; set; }
    public string? ProductName { get; set; }
    [Required]
    public int Qty { get; set; }
    [Required]
    public Decimal Price { get; set; }
    public Decimal? Discount { get; set; }
    

    public Order Order { get; set; }
    
}