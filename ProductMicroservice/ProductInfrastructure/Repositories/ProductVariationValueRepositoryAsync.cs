using ProductApplicationCore.Contracts.Repository;
using ProductApplicationCore.Entities;
using ProductInfrastructure.Data;

namespace ProductInfrastructure.Repositories;

public class ProductVariationValueRepositoryAsync:BaseRepositoryAsync<ProductVariationValues>, IProductVariationValueRepositoryAsync
{
    public ProductVariationValueRepositoryAsync(ProductDbContext dbContext): base(dbContext)
    {
    }
}

