using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReviewsApplicationCore.Entity;

public class Reviews
{
    public int Id { get; set; }
    public int? CustomerId { get; set; }
    [MaxLength(256), MinLength(2), Required]
    public string CustomerName { get; set; }
    public int? OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public int? ProductId { get; set; }
    [MaxLength(256), MinLength(2), Required]
    public string? ProductName { get; set; }
    public int RatingValue { get; set; }
    [MaxLength(500), MinLength(2), Required]
    public string? Commment { get; set; }
    public DateTime ReviewDate { get; set; }
    public bool? IsApproved { get; set; }
    
}