using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Model.RequestModels;
using ApplicationCore.Model.ResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomerServiceAsync _customerService;

    public CustomerController(ICustomerServiceAsync customerService)
    {
        _customerService = customerService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetCustomerAddressByUserId(int userId)
    {
        var address = await _customerService.GetCustomerAddressByUserId(userId);
        return Ok(address);
    }
    
    [HttpPost]
    public async Task<IActionResult> SaveCustomerAddress([FromBody] CustomerRequestModel reqCustomer)
    {
        var result = await _customerService.InsertAsync(reqCustomer);
        return Ok(result);
    }
}