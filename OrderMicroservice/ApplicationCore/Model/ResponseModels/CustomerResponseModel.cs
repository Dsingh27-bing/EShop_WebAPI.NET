namespace ApplicationCore.Model.ResponseModels;

public class CustomerResponseModel
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Gender { get; set; }
    public int? Phone { get; set; }
    public string? ProfilePic { get; set; }
    public int? UserId { get; set; }
    
    IEnumerable<UserAddressResponseModel> UserAddressResponseModels { get; set; }
    
}