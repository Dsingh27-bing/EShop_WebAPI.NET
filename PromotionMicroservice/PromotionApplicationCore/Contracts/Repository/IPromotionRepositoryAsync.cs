using PromotionApplicationCore.Entities;

namespace PromotionApplicationCore.Contracts.Repository;

public interface IPromotionRepositoryAsync: IRepositoryAsync<PromotionSale>
{
    public Task<IEnumerable<PromotionSale>> GetPromotionsByProductName(string productName);
    public Task<IEnumerable<PromotionSale>> GetActivePromotions(DateTime endDate);
}