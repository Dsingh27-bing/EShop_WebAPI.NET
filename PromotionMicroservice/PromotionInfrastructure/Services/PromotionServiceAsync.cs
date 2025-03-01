using AutoMapper;
using PromotionApplicationCore.Contracts.Repository;
using PromotionApplicationCore.Contracts.Services;
using PromotionApplicationCore.Entities;
using PromotionApplicationCore.Model;

namespace PromotionInfrastructure.Services;

public class PromotionServiceAsync:IPromotionServiceAsync
{
    private readonly IPromotionRepositoryAsync _repository;
    private readonly IMapper _mapper;

    public PromotionServiceAsync(IPromotionRepositoryAsync promotionRepository, IMapper mapper)
    {
        _repository = promotionRepository;
        _mapper = mapper;
    }


    public async Task<IEnumerable<PromotionResponseModel>> GetAllAsync()
    {
        var result = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<PromotionResponseModel>>(result);
    }

    public async Task<PromotionResponseModel> GetByIdAsync(int id)
    {
        var result = await _repository.GetByIdAsync(id);
        return _mapper.Map<PromotionResponseModel>(result);
    }

    public async Task<int> InsertAsync(PromotionRequestModel entity)
    {
        var response = _mapper.Map<PromotionSale>(entity);
        return await _repository.InsertAsync(response);
    }

    public async Task<int> UpdateAsync(PromotionRequestModel entity)
    {
        var response = _mapper.Map<PromotionSale>(entity);
        return await _repository.UpdateAsync(response);
    }

    public Task<int> DeleteAsync(int id)
    {
        return _repository.DeleteAsync(id);
    }
    
    public async Task<IEnumerable<PromotionResponseModel>> GetPromotionsByProductName(string productName)
    {
        var result = await _repository.GetPromotionsByProductName(productName);
        return _mapper.Map<IEnumerable<PromotionResponseModel>>(result);
    }
    
    public async Task<IEnumerable<PromotionResponseModel>> GetActivePromotions(DateTime endDate)
    {
        var result = await _repository.GetActivePromotions(endDate);
        return _mapper.Map<IEnumerable<PromotionResponseModel>>(result);
    }
}