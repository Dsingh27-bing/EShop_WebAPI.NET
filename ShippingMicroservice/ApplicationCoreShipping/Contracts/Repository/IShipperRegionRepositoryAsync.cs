using ApplicationCoreShipping.Entities;

namespace ApplicationCoreShipping.Contracts.Repository;

public interface IShipperRegionRepositoryAsync:IRepositoryAsync<ShipperRegion>
{
    public Task<IEnumerable<Shipper>> GetShipperByRegion(string region);
}