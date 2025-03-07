using ApplicationCoreShipping.Contracts.Services;
using ApplicationCoreShipping.Model;
using Microsoft.AspNetCore.Mvc;

namespace ShippingMicroservice.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class ShippingController : ControllerBase
{
  private readonly IShipperServiceAsync _shipperServiceAsync;

  public ShippingController(IShipperServiceAsync shipperServiceAsync)
  {
    _shipperServiceAsync = shipperServiceAsync;
  }
  
  [HttpGet]
  public async Task<IActionResult> GetAllShippers()
  {
    var shippers = await _shipperServiceAsync.GetAllAsync();
    return Ok(shippers);
  }
  
  [HttpGet("{id:int}")]
  public async Task<IActionResult> GetShipperById(int id)
  {
    var shipper = await _shipperServiceAsync.GetByIdAsync(id);
    return Ok(shipper);
  }
  
  [HttpPost]
  public async Task<IActionResult> SaveShipper([FromBody] ShippingRequestModel requestModel)
  {
    var result = await _shipperServiceAsync.InsertAsync(requestModel);
    return Ok(result);
  }
  
  [HttpPut]
  public async Task<IActionResult> UpdateShipper([FromBody] ShippingRequestModel requestModel)
  {
    var result = await _shipperServiceAsync.UpdateAsync(requestModel);
    return Ok(result);
  }
  
  [HttpDelete("{id:int}")]
  public async Task<IActionResult> Delete(int id)
  {
    var result = await _shipperServiceAsync.DeleteAsync(id);
    return Ok(result);
  }
  
  [HttpGet("shipper/region/{region}")]
  public async Task<IActionResult> GetShippersByRegion(string region)
  {
    var response = await _shipperServiceAsync.GetShipperByRegion(region);
    return Ok(response);
  }

  [HttpPut("[action]")]
  public async Task<IActionResult> UpdateOrderStatus(int id, [FromBody] OrderState status)
  {
    var response = await _orderServiceAsync.UpdateOrderStatusAsync(id, status);
    
    if (response != null)
    {
        return Ok();
    }
    return BadRequest();
  }
  
}