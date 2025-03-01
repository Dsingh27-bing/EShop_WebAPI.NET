using Microsoft.AspNetCore.Mvc;
using ProductApplicationCore.Contracts.Service;
using ProductApplicationCore.Model;

namespace ProductMicroservice.Controllers;
[ApiController]
[Route("api/[controller]/[action]")]
public class ProductController : ControllerBase
{
    private readonly IProductServiceAsync _productService;
    
    public ProductController(IProductServiceAsync productService)
    {
        _productService = productService;
    }
    
    // a. Get all Products
    [HttpGet]
    public async Task<IActionResult> GetListProducts()
    {
        var products = await _productService.GetAllAsync();
        return Ok(products);
    }
    
    // b. Save new Product
    [HttpPost]
    public async Task<IActionResult> Save([FromBody] ProductRequestModel request)
    {
        var result = await _productService.InsertAsync(request);
        return Ok(result);
    }
    
    // c. Get Product By Id
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetProductById(int id)
    {
        var product = await _productService.GetByIdAsync(id);
        return Ok(product);
    }
    
    // d. Delete the Product
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var result = await _productService.DeleteAsync(id);
        return Ok(result);
    }
    
    // e. Update the Product
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] ProductRequestModel request)
    {
        request.Id = id; // Ensure request has the correct ID if needed
        var result = await _productService.UpdateAsync(request);
        return Ok(result);
    }
    [HttpPut("{id:int}")]
    public async Task<IActionResult> InActive(int id, [FromBody] ProductRequestModel request)
    {
        request.Id = id; // Ensure request has the correct ID if needed
        var result = await _productService.UpdateAsync(request);
        return Ok(result);
    }
    
    [HttpGet("{categoryid:int}")]
    public async Task<IActionResult> GetProductByCategoryId(int categoryId)
    {
        var product = await _productService.GetProductByCategoryIdAsync(categoryId);
        return Ok(product);
    }
    [HttpGet]
    public async Task<IActionResult> GetProductByName(string name)
    {
        var product = await _productService.GetProductByNameAsync(name);
        return Ok(product);
        
    }
    
    
}