
using Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Controller;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
    private readonly IAuthService _authService;
    public UserController(IAuthService authService)
    {
        _authService = authService;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public IActionResult Login(LoginInput input)
    {
        LoginOutput output = _authService.Login(input);
        return Ok(output);
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterInput input)
    {
        if(!ModelState.IsValid)   
            return BadRequest("Error");
        else
        {
            bool response = _authService.Register(input);
            return Ok(response);
        }

    }
}
