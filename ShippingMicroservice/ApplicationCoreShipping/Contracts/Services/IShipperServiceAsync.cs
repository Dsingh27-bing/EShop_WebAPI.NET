using ApplicationCoreShipping.Model;

namespace ApplicationCoreShipping.Contracts.Services;

public interface IShipperServiceAsync
{
    public Task<IEnumerable<ShippingResponseModel>> GetAllAsync();
    public Task<ShippingResponseModel> GetByIdAsync(int id);
    public Task<int> InsertAsync(ShippingRequestModel reqModel);
    public Task<int> UpdateAsync(ShippingRequestModel reqModel);
    public Task<int> DeleteAsync(int id);
}