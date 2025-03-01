using AutoMapper;
using ProductApplicationCore.Contracts.Repository;
using ProductApplicationCore.Contracts.Service;
using ProductApplicationCore.Entities;
using ProductApplicationCore.Model;

namespace ProductInfrastructure.Services;

public class ProductVariationServiceAsync:IProductVariationServiceAsync
{
    private readonly IMapper _mapper;
    private readonly IProductVariationValueRepositoryAsync _productVariationValueRepositoryAsync;

    public ProductVariationServiceAsync(IProductVariationValueRepositoryAsync productVariationValueRepositoryAsync, IMapper mapper)
    {
        _mapper = mapper;
        _productVariationValueRepositoryAsync = productVariationValueRepositoryAsync;
    }

    public async Task<IEnumerable<ProductVariationResponseModel>> GetAllAsync()
    {
        var responseModels = _mapper.Map<IEnumerable<ProductVariationResponseModel>>(await _productVariationValueRepositoryAsync.GetAllAsync());
        return responseModels;
    }

    public Task<int> InsertAsync(ProductVariationRequestModel reqModel)
    {
        var productVariation = _mapper.Map<ProductVariationValues>(reqModel);
        return _productVariationValueRepositoryAsync.InsertAsync(productVariation);
    }
}