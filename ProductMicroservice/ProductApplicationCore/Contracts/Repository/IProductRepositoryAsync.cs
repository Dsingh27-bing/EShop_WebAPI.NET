using ProductApplicationCore.Entities;

namespace ProductApplicationCore.Contracts.Repository;

public interface IProductRepositoryAsync:IRepositoryAsync<Product>
{
    public Task<IEnumerable<Product>> GetProductByCategoryId(int categoryId);
    public  Task<IEnumerable<Product>> GetProductByName(string name);
}