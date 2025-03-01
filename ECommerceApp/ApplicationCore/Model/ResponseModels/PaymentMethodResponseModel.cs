namespace ApplicationCore.Model.ResponseModels;

public class PaymentMethodResponseModel
{
    public int Id { get; set; }
    public int PaymentTypeId { get; set; }
    public string? Provider { get; set; }
    public DateTime? Expiry { get; set; }
    public string? IsDefault { get; set; }
}