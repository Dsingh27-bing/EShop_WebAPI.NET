using AuthenticationApplicationCore.Contracts.Service;
using AuthenticationApplicationCore.Model;
using JwtAuthenticationManager;
using JwtAuthenticationManager.Model;
using Microsoft.AspNetCore.Mvc;

namespace AuthMicroservice.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationServiceAsync _authenticationService;
    private readonly JWTTokenHandler _JwtTokenHandler;

    public AuthenticationController(IAuthenticationServiceAsync authenticationServiceAsync, JWTTokenHandler jWTTokenHandler)
    {
        _authenticationService = authenticationServiceAsync;
        this._JwtTokenHandler = jWTTokenHandler; ;
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
    
    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _authenticationService.GetAllAsync();
        return Ok(users);
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var user = await _authenticationService.GetByIdAsync(id);
        return Ok(user);
    }
    
    [HttpPost]
    public async Task<IActionResult> SaveUser([FromBody] UserRequestModel requestModel)
    {
        var result = await _authenticationService.InsertAsync(requestModel);
        return Ok(result);
    }
    
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UserRequestModel requestModel)
    {
        var result = await _authenticationService.UpdateAsync(requestModel);
        return Ok(result);
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _authenticationService.DeleteAsync(id);
        return Ok(result);
    }
}
