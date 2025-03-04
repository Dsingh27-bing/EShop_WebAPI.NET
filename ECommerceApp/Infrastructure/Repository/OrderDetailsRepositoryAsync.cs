using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class OrderDetailsRepositoryAsync:BaseRepositoryAsync<OrderDetails>,IOrderDetailsRepositoryAsync
{
    private readonly ECommerceDbContext orderDbContext;

    public OrderDetailsRepositoryAsync(ECommerceDbContext dbContext) : base(dbContext)
    {
        this.orderDbContext = dbContext;
    }

    public async Task<IEnumerable<OrderDetails>> GetOrderDetailsByOrderIdAsync(int orderId)
    {
        return await orderDbContext.OrderDetails.AsNoTracking()
            .Where(c => c.OrderId == orderId)
            .ToListAsync();
    }
}