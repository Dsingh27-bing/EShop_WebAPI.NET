namespace ApplicationCoreShipping.Entities;

public class Shipper
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? ContactPerson { get; set; }
    
    public IEnumerable<ShipperRegion> ShipperRegions { get; set; }
  
    public IEnumerable<ShippingDetails> ShippingDetails { get; set; }
}