using ApplicationCore.Entities;

namespace ApplicationCore.Model.RequestModels;

public class OrderRequestModel
{
        
        public int Id { get; set; }
        public DateTime? OrderDate { get; set; }
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? PaymentName { get; set; }
        public string? ShippingAddress { get; set; }
        public decimal? BillAmount { get; set; }
        public OrderStatus? OrderStatus { get; set; }
    
    
}