using ApplicationCoreShipping.Contracts.Repository;
using ApplicationCoreShipping.Contracts.Services;
using ApplicationCoreShipping.Entities;
using ApplicationCoreShipping.Model;
using AutoMapper;

namespace InfrastructureShipping.Services;

public class ShipperServiceAsync:IShipperServiceAsync
{
    private readonly IMapper _mapper;
    private readonly IShippingRepositoryAsync _shippingRepositoryAsync;

    public ShipperServiceAsync(IShippingRepositoryAsync shippingRepositoryAsync, IMapper mapper)
    {
        _mapper = mapper;
        _shippingRepositoryAsync = shippingRepositoryAsync;
    }
    public async Task<IEnumerable<ShippingResponseModel>> GetAllAsync()
    {
        var responseModels= _mapper.Map<IEnumerable<ShippingResponseModel>>(await _shippingRepositoryAsync.GetAllAsync());
        return responseModels;
    }

    public async Task<ShippingResponseModel> GetByIdAsync(int id)
    {
        var shipper = await _shippingRepositoryAsync.GetByIdAsync(id);
        var responseModel = _mapper.Map<ShippingResponseModel>(shipper);
        return responseModel;
    }

    public Task<int> InsertAsync(ShippingRequestModel reqModel)
    {
        var shipper = _mapper.Map<Shipper>(reqModel);
        return _shippingRepositoryAsync.InsertAsync(shipper);
    }

    public Task<int> UpdateAsync(ShippingRequestModel reqModel)
    {
        var shipper = _mapper.Map<Shipper>(reqModel);
        return _shippingRepositoryAsync.UpdateAsync(shipper);
    }

    public Task<int> DeleteAsync(int id)
    {
        return _shippingRepositoryAsync.DeleteAsync(id);
    }
}