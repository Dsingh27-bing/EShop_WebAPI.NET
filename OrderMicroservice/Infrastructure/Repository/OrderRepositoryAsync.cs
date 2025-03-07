using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class OrderRepositoryAsync:BaseRepositoryAsync<Order>,IOrderRepositoryAsync
{
    private readonly ECommerceDbContext _dbContext;
    public OrderRepositoryAsync(ECommerceDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<PaymentMethod>>GetPaymentsByCustomerIdAsync(int customerId)
    {
        return await _dbContext.Orders.AsNoTracking()
            .Where(o => o.CustomerId == customerId)
            .SelectMany(o => o.PaymentMethods)
            .ToListAsync();

    }

    public async Task<Order> GetOrderWithDetailbyIdAsync(int id)
    {
        return  await _dbContext.Orders.AsNoTracking()
            .Include(o => o.OrderDetails)
            .FirstOrDefaultAsync(o => o.Id == id);
    }
}