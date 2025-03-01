using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class ShoppingCartItemRepositoryAsync:BaseRepositoryAsync<ShoppingCartItem>, IShoppingCartItemRepositoryAsync
{
    public ShoppingCartItemRepositoryAsync(ECommerceDbContext dbContext) : base(dbContext)
    {
    }
}