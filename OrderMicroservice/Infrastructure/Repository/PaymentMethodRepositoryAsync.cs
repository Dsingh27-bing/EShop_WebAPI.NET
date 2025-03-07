using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class PaymentMethodRepositoryAsync:BaseRepositoryAsync<PaymentMethod>, IPaymentMethodRepositoryAsync
{
     private readonly ECommerceDbContext _dbContext;

    public PaymentMethodRepositoryAsync(ECommerceDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
    
    
}