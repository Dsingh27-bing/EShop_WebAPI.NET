using Microsoft.AspNetCore.Mvc;
using PromotionApplicationCore.Contracts.Services;
using PromotionApplicationCore.Model;

namespace PromotionMicroservice.Controllers;
[ApiController]
[Route("api/[controller]/[action]")]
public class PromotionController : ControllerBase
{
    private readonly IPromotionServiceAsync _promotionServiceAsync;

    public PromotionController(IPromotionServiceAsync promotionServiceAsync)
    {
        _promotionServiceAsync = promotionServiceAsync;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllPromotions()
    {
        var promotions = await _promotionServiceAsync.GetAllAsync();
        return Ok(promotions);
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetPromotionById(int id)
    {
        var promotion = await _promotionServiceAsync.GetByIdAsync(id);
        return Ok(promotion);
    }
    
    [HttpPost]
    public async Task<IActionResult> SavePromotion([FromBody] PromotionRequestModel requestModel)
    {
        var result = await _promotionServiceAsync.InsertAsync(requestModel);
        return Ok(result);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdatePromotion([FromBody] PromotionRequestModel requestModel)
    {
        var result = await _promotionServiceAsync.UpdateAsync(requestModel);
        return Ok(result);
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeletePromotion(int id)
    {
        var result = await _promotionServiceAsync.DeleteAsync(id);
        return Ok(result);
    }
    
    [HttpGet("{productId:int}")]
    public async Task<IActionResult> GetPromotionsByProductName(string productName)
    {
        var promotions = await _promotionServiceAsync.GetPromotionsByProductName(productName);
        return Ok(promotions);
    }
    
    [HttpGet("{endDate:DateTime}")]
    public async Task<IActionResult> ActivePromotions(DateTime endDate)
    {
        var promotions = await _promotionServiceAsync.GetActivePromotions(endDate);
        return Ok(promotions);
    }
    
}