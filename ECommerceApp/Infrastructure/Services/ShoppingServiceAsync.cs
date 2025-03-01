using ApplicationCore.Contracts.Repository;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Model.RequestModels;
using ApplicationCore.Model.ResponseModels;
using AutoMapper;

namespace Infrastructure.Services;

public class ShoppingServiceAsync:IShoppingServiceAsync
{
    private readonly IShoppingCartRepositoryAsync _shoppingCartRepositoryAsync;
    private readonly IMapper _mapper;

    public ShoppingServiceAsync(IShoppingCartRepositoryAsync shoppingCartRepositoryAsync, IMapper mapper)
    {
        _shoppingCartRepositoryAsync = shoppingCartRepositoryAsync;
        _mapper = mapper;
    }
    public async Task<IEnumerable<ShoppingCartResponseModel>> GetShoppingCartByCustomerId(int customerId)
    {
        var shoppingCarts = await _shoppingCartRepositoryAsync.GetByIdAsync(customerId);
        var responseModels = _mapper.Map<IEnumerable<ShoppingCartResponseModel>>(shoppingCarts);
        return responseModels;
    }

    public Task<int> SaveShoppingCart(ShoppingCartRequestModel requestModel)
    {
        var shoppingCartIn = _mapper.Map<ShoppingCart>(requestModel);
        return _shoppingCartRepositoryAsync.InsertAsync(shoppingCartIn);
    }

    public Task<int> DeleteShoppingCart(int shoppingCartId)
    {
        return _shoppingCartRepositoryAsync.DeleteAsync(shoppingCartId);
    }

    public Task<int> InsertAsync(ShoppingCartRequestModel entity)
    {
        var shoppingCartIn = _mapper.Map<ShoppingCart>(entity);
        return _shoppingCartRepositoryAsync.InsertAsync(shoppingCartIn);
    }

    public Task<int> DeleteAsync(int id)
    {
        return _shoppingCartRepositoryAsync.DeleteAsync(id);
    }
}