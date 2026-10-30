
using Microsoft.AspNetCore.Mvc;

namespace Git_History_Demo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HealthController : ControllerBase
{
    [HttpGet]
    public IActionResult GetHealth()
    {
        return Ok(new
        {
            Status = "Healthy",
            Service = "Git History Demo API",
            Timestamp = DateTime.UtcNow
        });
    }
}
