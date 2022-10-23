using Microsoft.AspNetCore.Mvc;

namespace MyCash.Api.Controllers;

[ApiController]
[Route("api")]
public class HomeController : ControllerBase
{
    [HttpGet("status")]
    public IActionResult Get()
    {
        return Ok("A Api está online!");
    }
}
