using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class PaymentTypeRepositoryAsync:BaseRepositoryAsync<PaymentType>, IPaymentTypeRepositoryAsync
{
    public PaymentTypeRepositoryAsync(ECommerceDbContext dbContext): base(dbContext)
    {
    }
}