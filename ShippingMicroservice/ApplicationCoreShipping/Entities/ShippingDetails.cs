namespace ApplicationCoreShipping.Entities
{

    public class ShippingDetails
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ShipperId { get; set; }
        public string ShipperStatus { get; set; }
        public string? TrackingNumber { get; set; }

        public Shipper Shipper { get; set; }
    }
    
}
