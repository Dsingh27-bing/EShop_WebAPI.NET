using AutoMapper;
using ProductApplicationCore.Contracts.Repository;
using ProductApplicationCore.Contracts.Service;
using ProductApplicationCore.Entities;
using ProductApplicationCore.Model;

namespace ProductInfrastructure.Services;

public class VariationValueServiceAsync:IVariationValueServiceAsync
{
    private readonly IMapper _mapper;
    private readonly IVariationValueRepositoryAsync _variationValueRepositoryAsync;

    public VariationValueServiceAsync(IVariationValueRepositoryAsync variationValueRepositoryAsync, IMapper mapper)
    {
        _mapper = mapper;
        _variationValueRepositoryAsync = variationValueRepositoryAsync;
        
    }


    public async Task<VariationResponseModel> GetByIdAsync(int id)
    {
        var variation = await _variationValueRepositoryAsync.GetByIdAsync(id);
        var responseModel = _mapper.Map<VariationResponseModel>(variation);
        return responseModel;
    }

    public Task<int> InsertAsync(VariationRequestModel reqModel)
    {
        var variation = _mapper.Map<VariationValue>(reqModel);
        return _variationValueRepositoryAsync.InsertAsync(variation);
    }
}