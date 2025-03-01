namespace ApplicationCore.Model.ResponseModels;

public class ShoppingCartItemResponseModel
{
    public int Id { get; set; }
    public int? CartId { get; set; }
    public int? ProductId { get; set; }
    public String? ProductName { get; set; }
    public int? Qty { get; set; }
    public Decimal? Price { get; set; }
}