using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class OrderDetailsRepositoryAsync:BaseRepositoryAsync<OrderDetails>,IOrderDetailsRepositoryAsync
{
    public OrderDetailsRepositoryAsync(ECommerceDbContext dbContext) : base(dbContext)
    {
    }
}