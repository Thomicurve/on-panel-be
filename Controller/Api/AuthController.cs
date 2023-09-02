using Application;
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

    [HttpPost("login")]
    public IActionResult Login(LoginInput input)
    {
        var output = _authService.Login(input);
        return Ok(output);
    }

    [HttpPost("register")]
    public IActionResult Login(RegisterInput input)
    {
        return Ok();
    }
}
