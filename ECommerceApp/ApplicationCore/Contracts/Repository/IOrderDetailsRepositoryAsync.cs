using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repository;

public interface IOrderDetailsRepositoryAsync:IRepositoryAsync<OrderDetails>
{
    Task<IEnumerable<OrderDetails>> GetOrderDetailsByOrderIdAsync(int orderId); 
}