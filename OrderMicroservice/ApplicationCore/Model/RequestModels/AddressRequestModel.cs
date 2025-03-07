namespace ApplicationCore.Model.RequestModels;

public class AddressRequestModel
{
    public int Id { get; set; }
    public String? Street1 { get; set; }
    public String? Street2 { get; set; }
    public String? City { get; set; }
    public String? State { get; set; }
    public String? Country { get; set; }
    public String? ZipCode { get; set; }
    
    public int CustomerId { get; set; }
    public String IsDefaultAddress { get; set; }

}