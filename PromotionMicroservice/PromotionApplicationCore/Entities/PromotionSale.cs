namespace PromotionApplicationCore.Entities;

public class PromotionSale
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public Decimal? Discount { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    
    public IEnumerable<PromotionDetails> PromotionDetails { get; set; }
}