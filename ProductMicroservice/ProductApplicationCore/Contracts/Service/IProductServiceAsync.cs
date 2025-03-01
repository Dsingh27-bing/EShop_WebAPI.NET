using ProductApplicationCore.Model;

namespace ProductApplicationCore.Contracts.Service;

public interface IProductServiceAsync
{
    public Task<IEnumerable<ProductResponseModel>> GetAllAsync();
    public Task<ProductResponseModel> GetByIdAsync(int id);
    public Task<int> InsertAsync(ProductRequestModel requestModel);
    public Task<int> UpdateAsync(ProductRequestModel requestModel);
    public Task<int> DeleteAsync(int id);

    public Task<IEnumerable<ProductResponseModel>> GetProductByCategoryIdAsync(int categoryId);

    public Task<IEnumerable<ProductResponseModel>> GetProductByNameAsync(string name);

}