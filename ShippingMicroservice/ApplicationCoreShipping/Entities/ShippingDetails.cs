namespace ApplicationCoreShipping.Entities
{

    public class ShippingDetails
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ShipperId { get; set; }
        public ShipperStatus ShipperStatus { get; set; }
        public string? TrackingNumber { get; set; }
    }
    public enum ShipperStatus
    {
        Pending,
        Shipped,
        Delivered
    }
}
