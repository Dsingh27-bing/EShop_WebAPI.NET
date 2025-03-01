using Microsoft.AspNetCore.Mvc;
using ReviewsApplicationCore.Contracts.Services;
using ReviewsApplicationCore.Model;

namespace ReviewsMicroservice.Controllers;
[ApiController]
[Route("api/[controller]/[action]")]
public class CustomerReviewsController : ControllerBase
{
    private readonly IReviewsServiceAsync _reviewsServiceAsync;

    public CustomerReviewsController(IReviewsServiceAsync reviewsServiceAsync)
    {
        _reviewsServiceAsync = reviewsServiceAsync;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllReviews()
    {
        var reviews = await _reviewsServiceAsync.GetAllAsync();
        return Ok(reviews);
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetReviewById(int id)
    {
        var review = await _reviewsServiceAsync.GetByIdAsync(id);
        return Ok(review);
    }
    
    [HttpPost]
    public async Task<IActionResult> SaveReview([FromBody] ReviewsRequestModel requestModel)
    {
        var result = await _reviewsServiceAsync.InsertAsync(requestModel);
        return Ok(result);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateReview([FromBody] ReviewsRequestModel requestModel)
    {
        var result = await _reviewsServiceAsync.UpdateAsync(requestModel);
        return Ok(result);
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteReview(int id)
    {
        var result = await _reviewsServiceAsync.DeleteAsync(id);
        return Ok(result);
    }
    
    [HttpGet("{productId:int}")]
    public async Task<IActionResult> GetReviewsByProductId(int productId)
    {
        var reviews = await _reviewsServiceAsync.GetReviewsByProductId(productId);
        return Ok(reviews);
    }
    
    [HttpGet("{userId:int}")]
    public async Task<IActionResult> GetReviewsByUserId(int userId)
    {
        var reviews = await _reviewsServiceAsync.GetReviewsByUserId(userId);
        return Ok(reviews);
    }
    
    [HttpGet("{year:int}")]
    public async Task<IActionResult> GetReviewsByYear(int year)
    {
        var reviews = await _reviewsServiceAsync.GetReviewsByYear(year);
        return Ok(reviews);
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> ApproveReview(int id)
    {
        var review = await _reviewsServiceAsync.ApproveReview(id);
        return Ok(review);
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> RejectReview(int id)
    {
        var review = await _reviewsServiceAsync.RejectReview(id);
        return Ok(review);
    }
    
}