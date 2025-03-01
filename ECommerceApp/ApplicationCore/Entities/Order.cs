using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities
{
    public class Order
    {
        public int Id { get; set; }
        [Required] public DateTime OrderDate { get; set; }
        [Required] [ForeignKey("Customer")] public int CustomerId { get; set; }
        public String? CustomerName { get; set; }
        [ForeignKey("PaymentMethod")] public int? PaymentMethodId { get; set; }
        public String? PaymentName { get; set; }
        public String? ShippingAddress { get; set; }
        public String? ShippingMethod { get; set; }
        [Required] public Decimal BillAmount { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public IEnumerable<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();
        public Customer? Customer { get; set; }
        public IEnumerable<PaymentMethod> PaymentMethods { get; set; }


    }

    public enum OrderStatus
    {
        Pending,
        Processing,
        Shipped,
        Delivered,
        Completed,
        Canceled,
        Returned
    }
}