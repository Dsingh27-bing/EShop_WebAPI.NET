using ApplicationCoreShipping.Contracts.Repository;
using ApplicationCoreShipping.Entities;
using InfrastructureShipping.Data;

namespace InfrastructureShipping.Repository;

public class ShipperRegionRepositoryAsync: BaseRepositoryAsync<ShipperRegion>, IShipperRegionRepositoryAsync
{
    public ShipperRegionRepositoryAsync(ShippingDbContext dbContext): base(dbContext)
    {
    }
    
}