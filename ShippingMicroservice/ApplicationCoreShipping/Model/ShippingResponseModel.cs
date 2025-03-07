namespace ApplicationCoreShipping.Model;

public class ShippingResponseModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? ContactPerson { get; set; }

    public IEnumerable<ShippingRegionResponseModel> ShippingRegions { get; set; }
}