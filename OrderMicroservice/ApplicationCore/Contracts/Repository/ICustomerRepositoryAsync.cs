using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repository;

public interface ICustomerRepositoryAsync:IRepositoryAsync<Customer>
{
    public Task<IEnumerable<Customer>> GetCustomerAddressByUserIdAsync(int userId);
}