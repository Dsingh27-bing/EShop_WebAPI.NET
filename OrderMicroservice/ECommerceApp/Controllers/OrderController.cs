using Microsoft.AspNetCore.Mvc;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Helper;
using ApplicationCore.Model.RequestModels;
using ApplicationCore.Model.ResponseModels;
using Newtonsoft.Json;

namespace ECommerceApp.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderServiceAsync _orderService;
        Notification notification;
        public OrderController(IOrderServiceAsync orderService)
        {
            _orderService = orderService;
            notification = new Notification();
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
        
        [HttpPost]
        public async Task<IActionResult> SaveOrder([FromBody] OrderRequestModel request)
        {
            var result = await _orderService.InsertAsync(request);
            return Ok(result);
        }
        
        [HttpGet]
        public async Task<IActionResult> CheckOrderHistory(int orderId)
        {
            var orderDetails = await _orderService.CheckOrderHistory(orderId);
            return Ok(orderDetails);
        }

        [HttpGet]
        public async Task<IActionResult> CheckOrderStatus(int orderId)
        {
            var orderDetails = await _orderService.CheckOrderStatus(orderId);
            return Ok(orderDetails);
        }

        [HttpPut]
        public async Task<IActionResult> CancelOrder(int orderId)
        {
            try
            {
                var response = await _orderService.CancelOrder(orderId);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> OrderCompleted(int orderId)
        {
            var response = await _orderService.OrderCompleted(orderId);
            await notification.AddMessagetoQueue(JsonConvert.SerializeObject(response));
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderStatus(int orderId,OrderStatus status)
        {
            
            var response = await _orderService.UpdateOrderStatus(orderId, status);
            if (response)
            {
                return Ok();
            }
            return BadRequest();
            
        }
        
      
    }
}