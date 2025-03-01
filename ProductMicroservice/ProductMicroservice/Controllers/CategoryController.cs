using Microsoft.AspNetCore.Mvc;
using ProductApplicationCore.Contracts.Service;
using ProductApplicationCore.Model;

namespace ProductMicroservice.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryServiceAsync _categoryServiceAsync;

    public CategoryController(ICategoryServiceAsync categoryServiceAsync)
    {
        _categoryServiceAsync = categoryServiceAsync;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllCategory()
    {
        var categories = await _categoryServiceAsync.GetAllAsync();
        return Ok(categories);
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetCategoryById(int id)
    {
        var category = await _categoryServiceAsync.GetByIdAsync(id);
        return Ok(category);
    }
    
    [HttpPost]
    public async Task<IActionResult> SaveCategory([FromBody] ProductCategoryRequestModel requestModel)
    {
        var result = await _categoryServiceAsync.SaveCategory(requestModel);
        return Ok(result);
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _categoryServiceAsync.Delete(id);
        return Ok(result);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetCategoryByParentId(int parentId)
    {
        var categories = await _categoryServiceAsync.GetCategoryByParentId(parentId);
        return Ok(categories);
    }
    
    
}