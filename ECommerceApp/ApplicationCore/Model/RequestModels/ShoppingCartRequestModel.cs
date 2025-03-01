namespace ApplicationCore.Model.RequestModels;

public class ShoppingCartRequestModel
{
    public int Id { get; set; }
    public int? CustomerId { get; set; }
    public string? CustomerName { get; set; }
}