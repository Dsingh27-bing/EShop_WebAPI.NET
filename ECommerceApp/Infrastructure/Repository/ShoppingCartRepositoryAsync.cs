using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entities;
using ApplicationCore.Model.ResponseModels;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class ShoppingCartRepositoryAsync:BaseRepositoryAsync<ShoppingCart>, IShoppingCartRepositoryAsync
{
    private readonly ECommerceDbContext orderDbContext;

    public ShoppingCartRepositoryAsync(ECommerceDbContext dbContext): base(dbContext)
    {
        orderDbContext = dbContext;
    }

    public async Task<IEnumerable<ShoppingCart>> GetShoppingCartByCustomerId(int customerId)
    {
        return await orderDbContext.ShoppingCarts.AsNoTracking()
            .Where(c => c.CustomerId == customerId)
            .Include(c => c.ShoppingCartItems)
            .ToListAsync();
    }
}
