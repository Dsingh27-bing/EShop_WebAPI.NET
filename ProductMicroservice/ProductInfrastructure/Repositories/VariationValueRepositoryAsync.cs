using ProductApplicationCore.Contracts.Repository;
using ProductApplicationCore.Entities;
using ProductInfrastructure.Data;

namespace ProductInfrastructure.Repositories;

public class VariationValueRepositoryAsync:BaseRepositoryAsync<VariationValue>, IVariationValueRepositoryAsync
{
    public VariationValueRepositoryAsync(ProductDbContext dbContext): base(dbContext)
    {
    }
    
}