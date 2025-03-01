namespace ApplicationCore.Model.RequestModels;

public class UserAddressRequestModel
{
    public int Id { get; set; }
    public int? CustomerId { get; set; }
    public int? AddressId { get; set; }
    public String? IsDefaultAddress { get; set; }
    
}