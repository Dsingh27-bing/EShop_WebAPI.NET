using Microsoft.AspNetCore.Mvc;
using ProductApplicationCore.Contracts.Repository;
using ProductApplicationCore.Contracts.Service;
using ProductApplicationCore.Entities;
using ProductApplicationCore.Model;

namespace ProductMicroservice.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class VariationValueController : ControllerBase
{
    private readonly IVariationValueServiceAsync _variationValueServiceAsync;

    public VariationValueController(IVariationValueServiceAsync variationValueServiceAsync)
    {
        _variationValueServiceAsync = variationValueServiceAsync;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetVariationById(int id)
    {
        var variation = await _variationValueServiceAsync.GetByIdAsync(id);
        return Ok(variation);
    }
    
    [HttpPost]
    public async Task<IActionResult> Save([FromBody] VariationRequestModel request)
    {
        var result = await _variationValueServiceAsync.InsertAsync(request);
        return Ok(result);
    }
    
}