namespace ApplicationCore.Model.RequestModels;

public class OrderDetailsRequestModel
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public String? ProductName { get; set; }
    public int Qty { get; set; }
    public Decimal Price { get; set; }
    public Decimal? Discount { get; set; }
    
}