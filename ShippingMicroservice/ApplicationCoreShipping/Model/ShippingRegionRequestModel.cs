namespace ApplicationCoreShipping.Model;

public class ShippingRegionRequestModel
{
    public int RegionId { get; set; }
    public int ShipperId { get; set; }
    public bool Active { get; set; }
}