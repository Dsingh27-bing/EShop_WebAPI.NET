using ApplicationCoreShipping.Contracts.Repository;
using ApplicationCoreShipping.Entities;
using InfrastructureShipping.Data;

namespace InfrastructureShipping.Repository;

public class ShippingRepositoryAsync:BaseRepositoryAsync<Shipper>, IShippingRepositoryAsync
{
    public ShippingRepositoryAsync(ShippingDbContext dbContext): base(dbContext)
    {
    }
}