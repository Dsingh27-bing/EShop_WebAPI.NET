using Microsoft.AspNetCore.Mvc;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Model.RequestModels;
using ApplicationCore.Model.ResponseModels;

namespace ECommerceApp.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderServiceAsync _orderService;

        public OrderController(IOrderServiceAsync orderService)
        {
            _orderService = orderService;
        }

        // a. Get all Orders
        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _orderService.GetAllAsync();
            return Ok(orders);
        }

        // b. Save new Order
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderRequestModel request)
        {
            var result = await _orderService.InsertAsync(request);
            return Ok(result);
        }

        // c. Get Order By Customer Id
        [HttpGet("customer/{customerId:int}")]
        public async Task<IActionResult> GetOrdersByCustomerId(int customerId)
        {
            var orders = await _orderService.GetOrderByCustomerId(customerId);
            return Ok(orders);
        }

        // d. Delete the Order
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var result = await _orderService.DeleteByIdAsync(id);
            return Ok(result);
        }

        // e. Update the Order
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] OrderRequestModel request)
        {
            request.Id = id; // Ensure request has the correct ID if needed
            var result = await _orderService.UpdateAsync(request);
            return Ok(result);
        }
        
      
    }
}