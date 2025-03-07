using ApplicationCoreShipping.Contracts.Repository;
using ApplicationCoreShipping.Entities;
using InfrastructureShipping.Data;

namespace InfrastructureShipping.Repository;

public class ShipperRegionRepositoryAsync: BaseRepositoryAsync<ShipperRegion>, IShipperRegionRepositoryAsync
{
    private readonly ShippingDbContext _shippingDbContext;

    public ShipperRegionRepositoryAsync(ShippingDbContext dbContext): base(dbContext)
    {
        _shippingDbContext = dbContext;
    }

    public async Task<IEnumerable<Shipper>> GetShipperByRegion(string region)
    {
        return await _shippingDbContext.Regions.AsNoTracking()
            .Where(r => r.Name == region)
            .SelectMany(r => r.ShipperRegions.Select(sr => sr.Shipper))
            .ToListAsync();
    }
    
}