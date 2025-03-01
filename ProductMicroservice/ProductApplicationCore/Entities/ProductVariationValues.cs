namespace ProductApplicationCore.Entities;

public class ProductVariationValues
{
    public int ProductId { get; set; }
    public int VariationValueId { get; set; }
    
    public Product Product { get; set; }
    public VariationValue VariationValue { get; set; }
}