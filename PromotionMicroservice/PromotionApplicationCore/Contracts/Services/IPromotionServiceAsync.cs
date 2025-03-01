using PromotionApplicationCore.Entities;
using PromotionApplicationCore.Model;

namespace PromotionApplicationCore.Contracts.Services;

public interface IPromotionServiceAsync
{
    public Task<IEnumerable<PromotionResponseModel>> GetAllAsync();
    public Task<PromotionResponseModel> GetByIdAsync(int id);
    public Task<int> InsertAsync(PromotionRequestModel entity);
    public Task<int> UpdateAsync(PromotionRequestModel entity);
    public Task<int> DeleteAsync(int id);

    public Task<IEnumerable<PromotionResponseModel>> GetPromotionsByProductName(string productName);
    public Task<IEnumerable<PromotionResponseModel>> GetActivePromotions(DateTime endDate);
    
}