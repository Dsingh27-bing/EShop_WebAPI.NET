namespace ProductApplicationCore.Model;

public class ProductRequestModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public string? ProductImage { get; set; }
    public int CategoryId { get; set; }
    public int Qty { get; set; }
}