using ApplicationCore.Contracts.Services;
using ApplicationCore.Model.RequestModels;
using ApplicationCore.Model.ResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Controllers;
[ApiController]
[Route("api/[controller]/[action]")]
public class ShoppingCartItemController : Controller
{
    private readonly IShoppingCartItemServiceAsync _shoppingCartItemService;

    public ShoppingCartItemController(IShoppingCartItemServiceAsync shoppingCartItemService)
    {
        _shoppingCartItemService = shoppingCartItemService;
    }
    
    
    [HttpDelete]
    public async Task<IActionResult> DeleteShoppingCartItem(int shoppingCartItemId)
    {
        var result = await _shoppingCartItemService.DeleteAsync(shoppingCartItemId);
        return Ok(result);
    }
}