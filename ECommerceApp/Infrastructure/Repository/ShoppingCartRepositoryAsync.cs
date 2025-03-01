using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class ShoppingCartRepositoryAsync:BaseRepositoryAsync<ShoppingCart>, IShoppingCartRepositoryAsync
{
    public ShoppingCartRepositoryAsync(ECommerceDbContext dbContext): base(dbContext)
    {
    }
}
