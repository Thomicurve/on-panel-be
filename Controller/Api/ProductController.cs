using Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Controller;

[Authorize]
[ApiController]
[Route("api/productos")]
public class ProductController : ControllerBase
{
    private readonly OnPanelAppContext _appContext;
    public ProductController(OnPanelAppContext appContext)
    {
        _appContext = appContext;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok($"Productos del {_appContext.UserId}");
    }
}
