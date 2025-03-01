using ApplicationCore.Contracts.Services;
using ApplicationCore.Model.RequestModels;
using ApplicationCore.Model.ResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Controllers;
[ApiController]
[Route("api/[controller]/[action]")]
public class ShoppingCartController : ControllerBase
{
    private readonly IShoppingServiceAsync _shoppingService;

    public ShoppingCartController(IShoppingServiceAsync shoppingService)
    {
        _shoppingService = shoppingService;
    }
    
    [HttpGet("{customerId}")]
    public async Task<IEnumerable<ShoppingCartResponseModel>> GetShoppingCartByCustomerId(int customerId)
    {
        var shoppingCart = await _shoppingService.GetShoppingCartByCustomerId(customerId);
        return shoppingCart;
    }
    
    [HttpPost]
    public async Task<IActionResult> SaveShoppingCart([FromBody] ShoppingCartRequestModel reqShoppingCart)
    {
        var result = await _shoppingService.InsertAsync(reqShoppingCart);
        return Ok(result);
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteShoppingCart(int shoppingCartId)
    {
        var result = await _shoppingService.DeleteAsync(shoppingCartId);
        return Ok(result);
    }
}