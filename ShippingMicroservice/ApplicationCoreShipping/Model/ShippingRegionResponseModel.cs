namespace ApplicationCoreShipping.Model;

public class ShippingRegionResponseModel
{
    public int RegionId { get; set; }
    public int ShipperId { get; set; }
    public bool Active { get; set; }

    public RegionResponseModel? Region { get; set; }
}