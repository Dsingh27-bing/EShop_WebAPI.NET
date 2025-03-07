using InventoryMicroservice.Helper;
using Microsoft.AspNetCore.Mvc;

namespace InventoryMicroservice.Controllers;
[Route( "api/[controller]/[action]" )]
[ApiController]
public class InventoryController : ControllerBase
{
    private RabbitMqReader queue;
    public InventoryController()
    {
        queue = new RabbitMqReader();
    }
    [HttpGet]
    public async Task<IActionResult> ReadMessage()
    {
        await queue.ReadMessage((message) =>
        {
            Console.WriteLine(message);
            return message;
        });
        return Ok();
    }
}