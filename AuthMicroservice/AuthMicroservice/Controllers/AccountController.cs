using JwtAuthenticationManager;
using JwtAuthenticationManager.Model;
using Microsoft.AspNetCore.Mvc;

namespace AuthMicroservice.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly JWTTokenHandler _JwtTokenHandler;

    public AccountController(JWTTokenHandler jWTTokenHandler)
    {
        this._JwtTokenHandler = jWTTokenHandler; 
    }
    
    [HttpPost]
    public ActionResult<AuthenticationResponse> Login([FromBody] AuthenticationRequest request)
    {
        var autheticationResponse= _JwtTokenHandler.GenerateToken((request));

        if (autheticationResponse == null)
        {
            return BadRequest("username or password is incorrect");
        }

        return Ok(autheticationResponse);
    }
}
