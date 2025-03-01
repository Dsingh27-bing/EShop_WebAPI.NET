using AutoMapper;
using ProductApplicationCore.Contracts.Repository;
using ProductApplicationCore.Contracts.Service;
using ProductApplicationCore.Entities;
using ProductApplicationCore.Model;

namespace ProductInfrastructure.Services;

public class CategoryVariationServiceAsync:ICategoryVariationServiceAsync
{
    private readonly IMapper _mapper;
    private readonly ICategoryVariationRepositoryAsync _categoryVariationRepositoryAsync;

    public CategoryVariationServiceAsync(ICategoryVariationRepositoryAsync categoryVariationRepositoryAsync, IMapper mapper)
    {
        _mapper = mapper;
        _categoryVariationRepositoryAsync = categoryVariationRepositoryAsync;
    }

    public async Task<IEnumerable<CategoryVariationResponseModel>> GetAllAsync()
    {
        var responseModels = _mapper.Map<IEnumerable<CategoryVariationResponseModel>>(await _categoryVariationRepositoryAsync.GetAllAsync());
        return (responseModels);
    }

    public async Task<CategoryVariationResponseModel> GetByIdAsync(int id)
    {
        var categoryVariation = await _categoryVariationRepositoryAsync.GetByIdAsync(id);
        var responseModel = _mapper.Map<CategoryVariationResponseModel>(categoryVariation);
        return responseModel;
    }

    public Task<int> InsertAsync(CategoryVariationRequestModel requestModel)
    {
        var categoryVariation = _mapper.Map<CategoryVariation>(requestModel);
        return _categoryVariationRepositoryAsync.InsertAsync(categoryVariation);
    }

    public async Task<IEnumerable<CategoryVariation>> GetCategoryVariationByCategoryId(int categoryId)
    {
        // var categoryVariation = await _categoryVariationRepositoryAsync.GetByIdAsync(categoryId);
        // var responseModel = _mapper.Map<CategoryVariation>(categoryVariation);
        // return responseModel;
        throw new System.NotImplementedException();
    }

    public Task<int> DeleteAsync(int id)
    {
        return _categoryVariationRepositoryAsync.DeleteAsync(id);
    }
}