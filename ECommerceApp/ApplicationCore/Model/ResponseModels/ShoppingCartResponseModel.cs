namespace ApplicationCore.Model.ResponseModels;

public class ShoppingCartResponseModel
{
    public int Id { get; set; }
    public int? CustomerId { get; set; }
    public string? CustomerName { get; set; }
}