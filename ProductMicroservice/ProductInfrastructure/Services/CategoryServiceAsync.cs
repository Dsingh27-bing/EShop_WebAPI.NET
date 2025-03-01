using AutoMapper;
using ProductApplicationCore.Contracts.Repository;
using ProductApplicationCore.Contracts.Service;
using ProductApplicationCore.Entities;
using ProductApplicationCore.Model;

namespace ProductInfrastructure.Services;

public class CategoryServiceAsync:ICategoryServiceAsync
{
    private readonly IProductCategoryRepositoryAsync _productCategoryRepositoryAsync;
    private readonly IMapper _mapper;

    public CategoryServiceAsync(IProductCategoryRepositoryAsync productCategoryRepositoryAsync, IMapper mapper)
    {
        _mapper = mapper;
        _productCategoryRepositoryAsync = productCategoryRepositoryAsync;
    }

    public async Task<IEnumerable<ProductCategory>> GetAllAsync()
    {
        var responseModels= _mapper.Map<IEnumerable<ProductCategory>>(await _productCategoryRepositoryAsync.GetAllAsync());
        return responseModels;
    }

    public async Task<ProductCategory> GetByIdAsync(int id)
    {
        var category = await _productCategoryRepositoryAsync.GetByIdAsync(id);
        var responseModel = _mapper.Map<ProductCategory>(category);
        return responseModel;
    }

    public Task<int> InsertAsync(ProductCategoryRequestModel requestModel)
    {
        var category = _mapper.Map<ProductCategory>(requestModel);
        return _productCategoryRepositoryAsync.InsertAsync(category);
    }

    public Task<int> DeleteAsync(int id)
    {
        return _productCategoryRepositoryAsync.DeleteAsync(id);
    }

    public async Task<IEnumerable<ProductCategory>> GetAllCategory()
    {
        var responseModels= _mapper.Map<IEnumerable<ProductCategory>>(await _productCategoryRepositoryAsync.GetAllAsync());
        return responseModels;
    }

    public Task<int> SaveCategory(ProductCategoryRequestModel requestModel)
    {
        var category = _mapper.Map<ProductCategory>(requestModel);
        return _productCategoryRepositoryAsync.InsertAsync(category);
    }

    public async Task<ProductCategory> GetCategoryById(int id)
    {
        var category = await _productCategoryRepositoryAsync.GetByIdAsync(id);
        var responseModel = _mapper.Map<ProductCategory>(category);
        return responseModel;
    }

    public Task<int> Delete(int id)
    {
        return _productCategoryRepositoryAsync.DeleteAsync(id);
    }

    public async Task<IEnumerable<ProductCategoryResponseModel>> GetCategoryByParentId(int parentId)
    {
        return _mapper.Map<IEnumerable<ProductCategoryResponseModel>>(await _productCategoryRepositoryAsync.GetCategoryByParentIdAsync(parentId));
    }
}