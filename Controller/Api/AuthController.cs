
using Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Controller;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    public AuthController(IAuthService authService)
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
    public IActionResult Login(RegisterInput input)
    {
        return Ok();
    }
}
