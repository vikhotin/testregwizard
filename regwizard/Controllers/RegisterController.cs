using Microsoft.AspNetCore.Mvc;

namespace Regwizard.Controllers;

[ApiController]
[Route("user")]
public class RegisterController : Controller
{
    [Route("register")]
    public IActionResult Test()
    {
        return Ok("Hello, world");
    }
}