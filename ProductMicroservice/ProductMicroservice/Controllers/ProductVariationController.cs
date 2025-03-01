using Microsoft.AspNetCore.Mvc;
using ProductApplicationCore.Contracts.Service;
using ProductApplicationCore.Model;

namespace ProductMicroservice.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class ProductVariationController : ControllerBase
{
    private readonly IProductVariationServiceAsync _productVariationServiceAsync;

    public ProductVariationController(IProductVariationServiceAsync productVariationServiceAsync)
    {
        _productVariationServiceAsync = productVariationServiceAsync;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllProductVariations()
    {
        var productVariations = await _productVariationServiceAsync.GetAllAsync();
        return Ok(productVariations);
    }
    
    [HttpPost]
    public async Task<IActionResult> Save([FromBody] ProductVariationRequestModel request)
    {
        var result = await _productVariationServiceAsync.InsertAsync(request);
        return Ok(result);
    }
    
}