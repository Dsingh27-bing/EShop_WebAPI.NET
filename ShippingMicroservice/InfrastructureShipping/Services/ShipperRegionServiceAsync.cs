using ApplicationCoreShipping.Contracts.Repository;
using ApplicationCoreShipping.Contracts.Services;
using ApplicationCoreShipping.Model;
using AutoMapper;

namespace InfrastructureShipping.Services;

public class ShipperRegionServiceAsync:IShipperRegionServiceAsync
{
    private readonly IMapper _mapper;
    private readonly IShipperRegionRepositoryAsync _shipperRegionRepositoryAsync;

    public ShipperRegionServiceAsync(IShipperRegionRepositoryAsync shipperRegionRepositoryAsync, IMapper mapper)
    {
        _mapper = mapper;
        _shipperRegionRepositoryAsync = shipperRegionRepositoryAsync;
    }


    public async Task<IEnumerable<ShippingResponseModel>> GetAllAsync()
    {
        var responseModels= _mapper.Map<IEnumerable<ShippingResponseModel>>(await _shipperRegionRepositoryAsync.GetAllAsync());
        return responseModels;
    }
}