using ProductApplicationCore.Entities;

namespace ProductApplicationCore.Contracts.Repository;

public interface IProductCategoryRepositoryAsync:IRepositoryAsync<ProductCategory>
{
    public Task<IEnumerable<ProductCategory>> GetCategoryByParentIdAsync(int parentId);
}