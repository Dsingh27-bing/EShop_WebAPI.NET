using ProductApplicationCore.Entities;
using ProductApplicationCore.Model;

namespace ProductApplicationCore.Contracts.Service;

public interface ICategoryServiceAsync
{
    Task<IEnumerable<ProductCategory>> GetAllAsync();
    Task<ProductCategory> GetByIdAsync(int id);
    Task<int> InsertAsync(ProductCategoryRequestModel requestModel);
    Task<int> DeleteAsync(int id);

    Task<IEnumerable<ProductCategory>> GetAllCategory();
    Task<int> SaveCategory(ProductCategoryRequestModel requestModel);
    Task<ProductCategory> GetCategoryById(int id);
    Task<int> Delete(int id);
    Task<IEnumerable<ProductCategoryResponseModel>> GetCategoryByParentId(int parentId);



}