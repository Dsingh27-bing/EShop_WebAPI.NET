using ApplicationCore.Contracts.Repository;
using ApplicationCore.Contracts.Services;
using AutoMapper;

namespace Infrastructure.Services;

public class ShoppingCartItemServiceAsync:IShoppingCartItemServiceAsync
{
    private readonly IShoppingCartItemRepositoryAsync _shoppingCartItemRepositoryAsync;
    private readonly IMapper _mapper;

    public ShoppingCartItemServiceAsync(IShoppingCartItemRepositoryAsync shoppingCartItemRepositoryAsync, IMapper mapper)
    {
        _shoppingCartItemRepositoryAsync = shoppingCartItemRepositoryAsync;
        _mapper = mapper;
    }
    public Task<int> DeleteShoppingCartItemById(int shoppingCartItemId)
    {
        return _shoppingCartItemRepositoryAsync.DeleteAsync(shoppingCartItemId);
    }

    public Task<int> DeleteAsync(int shoppingCartItemId)
    {
        return _shoppingCartItemRepositoryAsync.DeleteAsync(shoppingCartItemId);
    }
}