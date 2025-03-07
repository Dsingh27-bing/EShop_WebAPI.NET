namespace ApplicationCoreShipping.Entities;

public class ShipperRegion
{
    public int RegionId { get; set; }
    public int ShipperId { get; set; }
    public bool Active { get; set; }

    public Region Region { get; set; }
    public Shipper Shipper { get; set; }
}