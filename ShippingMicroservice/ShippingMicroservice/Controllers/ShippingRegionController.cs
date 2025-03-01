using ApplicationCoreShipping.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace ShippingMicroservice.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class ShippingRegionController : ControllerBase
{
    private readonly IShipperRegionServiceAsync _shipperRegionServiceAsync;

    public ShippingRegionController(IShipperRegionServiceAsync shipperRegionServiceAsync)
    {
        _shipperRegionServiceAsync = shipperRegionServiceAsync;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllShipperRegions()
    {
        var shipperRegions = await _shipperRegionServiceAsync.GetAllAsync();
        return Ok(shipperRegions);
    }
    
    
}