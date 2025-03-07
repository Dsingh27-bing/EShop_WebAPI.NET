using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repository;

public interface IShoppingCartRepositoryAsync:IRepositoryAsync<ShoppingCart>
{
    public Task<IEnumerable<ShoppingCart>> GetShoppingCartByCustomerId(int customerId);
}