using Microsoft.AspNetCore.Mvc;
using ProductApplicationCore.Contracts.Service;
using ProductApplicationCore.Model;

namespace ProductMicroservice.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class CategoryVariationController : ControllerBase
{
    private readonly ICategoryVariationServiceAsync _categoryVariationServiceAsync;

    public CategoryVariationController(ICategoryVariationServiceAsync categoryVariationServiceAsync)
    {
        _categoryVariationServiceAsync = categoryVariationServiceAsync;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var categoryVariations = await _categoryVariationServiceAsync.GetAllAsync();
        return Ok(categoryVariations);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetCategoryVariationById(int id)
    {
        var categoryVariation = await _categoryVariationServiceAsync.GetByIdAsync(id);
        return Ok(categoryVariation);
    }
    
    [HttpPost]
    public async Task<IActionResult> Save([FromBody] CategoryVariationRequestModel requestModel)
    {
        var result = await _categoryVariationServiceAsync.InsertAsync(requestModel);
        return Ok(result);
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _categoryVariationServiceAsync.DeleteAsync(id);
        return Ok(result);
    }
    
    [HttpGet("{categoryId:int}")]
    public async Task<IActionResult> GetCategoryVariationByCategoryId(int categoryId)
    {
        var categoryVariation = await _categoryVariationServiceAsync.GetCategoryVariationByCategoryId(categoryId);
        return Ok(categoryVariation);
    }
}