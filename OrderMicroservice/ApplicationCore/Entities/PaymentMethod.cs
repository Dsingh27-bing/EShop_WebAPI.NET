namespace ApplicationCore.Entities;

public class PaymentMethod
{
    public int Id { get; set; }
    public int PaymentTypeId { get; set; }
    public string? Provider { get; set; }
    public long? AccountNumber { get; set; }
    public DateTime? Expiry { get; set; }
    public bool? IsDefault { get; set; }
    
    
    public PaymentType? PaymentType { get; set; }
    
}