namespace ApplicationCore.Model.ResponseModels;

public class OrderDetailsResponseModel
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public string? ProductName { get; set; }
    public int Qty { get; set; }
    public Decimal Price { get; set; }
    public Decimal? Discount { get; set; }
}