using AutoMapper;
using ProductApplicationCore.Contracts.Repository;
using ProductApplicationCore.Contracts.Service;
using ProductApplicationCore.Entities;
using ProductApplicationCore.Model;

namespace ProductInfrastructure.Services;

public class ProductServiceAsync:IProductServiceAsync
{
    private readonly IMapper _mapper;
    private readonly IProductRepositoryAsync _productRepositoryAsync;

    public ProductServiceAsync(IProductRepositoryAsync productRepositoryAsync, IMapper mapper)
    {
        _mapper = mapper;
        _productRepositoryAsync = productRepositoryAsync;
    }

    public async Task<IEnumerable<ProductResponseModel>> GetAllAsync()
    {
        var responseModels = _mapper.Map<IEnumerable<ProductResponseModel>>(await _productRepositoryAsync.GetAllAsync());
        return responseModels;
    }

    public async Task<ProductResponseModel> GetByIdAsync(int id)
    {
        var product = await _productRepositoryAsync.GetByIdAsync(id);
        var responseModel = _mapper.Map<ProductResponseModel>(product);
        return responseModel;
    }

    public Task<int> InsertAsync(ProductRequestModel requestModel)
    {
        var product = _mapper.Map<Product>(requestModel);
        return _productRepositoryAsync.InsertAsync(product);
    }

    public Task<int> UpdateAsync(ProductRequestModel requestModel)
    {
        var product = _mapper.Map<Product>(requestModel);
        return _productRepositoryAsync.UpdateAsync(product);
    }

    public Task<int> DeleteAsync(int id)
    {
        return _productRepositoryAsync.DeleteAsync(id);
    }


    public async Task<IEnumerable<ProductResponseModel>> GetProductByCategoryIdAsync(int categoryId)
    {
        return _mapper.Map<IEnumerable<ProductResponseModel>>(await _productRepositoryAsync.GetProductByCategoryId(categoryId));
    }

    public async Task<IEnumerable<ProductResponseModel>> GetProductByNameAsync(string name)
    {
        return _mapper.Map<IEnumerable<ProductResponseModel>>(await _productRepositoryAsync.GetProductByName(name));
    }
}