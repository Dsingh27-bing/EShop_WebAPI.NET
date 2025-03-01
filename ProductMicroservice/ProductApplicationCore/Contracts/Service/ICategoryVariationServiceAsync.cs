using ProductApplicationCore.Entities;
using ProductApplicationCore.Model;

namespace ProductApplicationCore.Contracts.Service;

public interface ICategoryVariationServiceAsync
{
    public Task<IEnumerable<CategoryVariationResponseModel>> GetAllAsync();
    public Task<CategoryVariationResponseModel> GetByIdAsync(int id);
    public Task<int> InsertAsync(CategoryVariationRequestModel requestModel);
    public Task<IEnumerable<CategoryVariation>> GetCategoryVariationByCategoryId(int categoryId);
    public Task<int> DeleteAsync(int id);
    
}