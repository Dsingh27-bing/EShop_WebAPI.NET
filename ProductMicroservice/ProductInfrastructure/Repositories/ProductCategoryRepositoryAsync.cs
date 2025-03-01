using Microsoft.EntityFrameworkCore;
using ProductApplicationCore.Contracts.Repository;
using ProductApplicationCore.Entities;
using ProductInfrastructure.Data;

namespace ProductInfrastructure.Repositories;

public class ProductCategoryRepositoryAsync:BaseRepositoryAsync<ProductCategory>, IProductCategoryRepositoryAsync
{
    private readonly ProductDbContext _DbContext;

    public ProductCategoryRepositoryAsync(ProductDbContext dbContext): base(dbContext)
    {
        _DbContext = dbContext;
    }
    
    public async Task<IEnumerable<ProductCategory>> GetCategoryByParentIdAsync(int parentId)
    {
        return await _DbContext.ProductCategory.AsNoTracking()
            .Where(c => c.ParentCategoryId == parentId).ToListAsync();
    }
}