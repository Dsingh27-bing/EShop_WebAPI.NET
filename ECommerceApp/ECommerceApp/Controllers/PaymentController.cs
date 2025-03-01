using ApplicationCore.Contracts.Services;
using ApplicationCore.Model.RequestModels;
using ApplicationCore.Model.ResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class PaymentController : ControllerBase
{
    private readonly IPaymentServiceAsync _paymentService;

    public PaymentController(IPaymentServiceAsync paymentService)
    {
        _paymentService = paymentService;
    }
    
    [HttpGet ("payment/{customerId}")]
    public async Task<IActionResult> GetPaymentByCustomerId(int customerId)
    {
        var payment = await _paymentService.GetByIdAsync(customerId);
        return Ok(payment);
    }
    
    [HttpPost]
    public async Task<IActionResult> SavePayment([FromBody] PaymentMethodRequestModel reqPayment)
    {
        var result = await _paymentService.InsertAsync(reqPayment);
        return Ok(result);
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeletePayment(int paymentId)
    {
        var result = await _paymentService.DeleteAsync(paymentId);
        return Ok(result);
    }
    [HttpPut]
    public async Task<IActionResult> UpdatePayment([FromBody] PaymentMethodRequestModel reqPayment)
    {
        var result = await _paymentService.UpdateAsync(reqPayment);
        return Ok(result);
    }
}