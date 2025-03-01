using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repository;

public interface IOrderRepositoryAsync:IRepositoryAsync<Order>
{
    Task<IEnumerable<PaymentMethod>> GetPaymentsByCustomerIdAsync(int customerId);
}