namespace ApplicationCore.Entities;

public class PaymentType
{
    public int Id { get; set; }
    public string? Name { get; set; }
    
    public IEnumerable<PaymentMethod> PaymentMethods { get; set; } = new List<PaymentMethod>();
}