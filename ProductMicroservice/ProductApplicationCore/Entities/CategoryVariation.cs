namespace ProductApplicationCore.Entities;

public class CategoryVariation
{
    public int Id { get; set; }
    public string? VariationName { get; set; }
    public int CategoryId { get; set; }
    
    public ProductCategory ProductCategory { get; set; }
}