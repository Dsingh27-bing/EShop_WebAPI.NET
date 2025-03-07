namespace ApplicationCore.Model.RequestModels;

public class PaymentMethodRequestModel
{
    public int Id { get; set; }
    public int PaymentTypeId { get; set; }
    public string? Provider { get; set; }
    public long? AccountNumber { get; set; }
    public DateTime? Expiry { get; set; }
    public string? IsDefault { get; set; }    
}