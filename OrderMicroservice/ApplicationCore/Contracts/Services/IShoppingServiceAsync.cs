using ApplicationCore.Model.RequestModels;
using ApplicationCore.Model.ResponseModels;

namespace ApplicationCore.Contracts.Services;

public interface IShoppingServiceAsync
{
    Task<IEnumerable<ShoppingCartResponseModel>> GetShoppingCartByCustomerId(int customerId);
    Task<int> SaveShoppingCart(ShoppingCartRequestModel requestModel); //insert
    Task<int> DeleteShoppingCart(int shoppingCartId); //delete
    
    Task<int> InsertAsync(ShoppingCartRequestModel entity);
    Task<int> DeleteAsync(int id);
}