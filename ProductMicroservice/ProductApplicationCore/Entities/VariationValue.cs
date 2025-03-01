namespace ProductApplicationCore.Entities;

public class VariationValue
{
    public int Id { get; set; }
    public double Value { get; set; }
    public int VariationId { get; set; }
    
    public CategoryVariation CategoryVariation { get; set; }
}