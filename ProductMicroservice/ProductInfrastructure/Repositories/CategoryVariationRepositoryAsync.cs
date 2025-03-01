using ProductApplicationCore.Contracts.Repository;
using ProductApplicationCore.Entities;
using ProductInfrastructure.Data;

namespace ProductInfrastructure.Repositories;

public class CategoryVariationRepositoryAsync:BaseRepositoryAsync<CategoryVariation>, ICategoryVariationRepositoryAsync
{
    public CategoryVariationRepositoryAsync(ProductDbContext dbContext): base(dbContext)
    {
    }
}
