using Microsoft.EntityFrameworkCore;
using PromotionApplicationCore.Contracts.Repository;
using PromotionApplicationCore.Entities;
using PromotionInfrastructure.Data;

namespace PromotionInfrastructure.Repository;

public class PromotionRepositoryAsync:BaseRepositoryAsync<PromotionSale>,IPromotionRepositoryAsync
{
    private readonly PromotionDbContext _dbContext;

    public PromotionRepositoryAsync(PromotionDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<PromotionSale>> GetPromotionsByProductName(string productName)
    {
        return await _dbContext.Promotions.AsNoTracking()
            .Where(x => x.PromotionDetails.Any(d => d.ProductCategoryName == productName))
            .ToListAsync();
    }
    
    public async Task<IEnumerable<PromotionSale>> GetActivePromotions(DateTime endDate)
    {
        return await _dbContext.Promotions.AsNoTracking()
            .Where(x => x.EndDate >= endDate)
            .ToListAsync();
    }
    
    
}