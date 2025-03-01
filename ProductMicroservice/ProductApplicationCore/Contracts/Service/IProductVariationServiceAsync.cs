using ProductApplicationCore.Model;

namespace ProductApplicationCore.Contracts.Service;

public interface IProductVariationServiceAsync
{
    public Task<IEnumerable<ProductVariationResponseModel>> GetAllAsync();
    Task<int> InsertAsync(ProductVariationRequestModel reqModel);
    
    
}