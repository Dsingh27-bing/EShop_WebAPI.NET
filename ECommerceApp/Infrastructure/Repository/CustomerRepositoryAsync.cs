using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class CustomerRepositoryAsync:BaseRepositoryAsync<Customer>,ICustomerRepositoryAsync
{
    private readonly ECommerceDbContext orderDbContext;

    public CustomerRepositoryAsync(ECommerceDbContext dbContext) : base(dbContext)
    {
        this.orderDbContext = dbContext;
    }
    public async Task<IEnumerable<Customer>> GetCustomerAddressByUserIdAsync(int userId)
    {
        return await orderDbContext.Customers.AsNoTracking()
            .Where(c => c.UserId == userId)
            .Include(c => c.UserAddresses)
            .ThenInclude(ua => ua.Address)
            .ToListAsync();
    }
}