namespace ApplicationCore.Contracts.Services;

public interface IShoppingCartItemServiceAsync
{
    Task<int> DeleteShoppingCartItemById(int shoppingCartItemId); //delete
    Task<int> DeleteAsync(int shoppingCartItemId); //delete
}