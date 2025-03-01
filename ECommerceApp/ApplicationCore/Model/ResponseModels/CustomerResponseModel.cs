namespace ApplicationCore.Model.ResponseModels;

public class CustomerResponseModel
{
    public int Id { get; set; }
    public String? FirstName { get; set; }
    public String? LastName { get; set; }
    public String? Gender { get; set; }
    public int? Phone { get; set; }
    public String? ProfilePic { get; set; }
    public int? UserId { get; set; }
    
    IEnumerable<UserAddressResponseModel> UserAddressResponseModels { get; set; }
    
}