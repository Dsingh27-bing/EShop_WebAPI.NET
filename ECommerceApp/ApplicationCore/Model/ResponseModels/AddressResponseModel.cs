namespace ApplicationCore.Model.ResponseModels;

public class AddressResponseModel
{
    public int Id { get; set; }
    public String? Street1 { get; set; }
    public String? Street2 { get; set; }
    public String? City { get; set; }
    public String? State { get; set; }
    public String? Country { get; set; }
    public String? ZipCode { get; set; }

}