namespace ApplicationCore.Model.ResponseModels;

public class UserAddressResponseModel
{
    public int Id { get; set; }
    public int? CustomerId { get; set; }
    public int? AddressId { get; set; }
    public String? IsDefaultAddress { get; set; }

    public AddressResponseModel AddressResponseModel { get; set; }
}