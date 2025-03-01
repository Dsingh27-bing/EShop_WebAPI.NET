using ApplicationCoreShipping.Model;

namespace ApplicationCoreShipping.Contracts.Services;

public interface IShipperRegionServiceAsync
{
    public Task<IEnumerable<ShippingResponseModel>>GetAllAsync();
}