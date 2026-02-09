using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet("simple")]
        public IActionResult Simple()
        {
            return Ok("Hello from test endpoint");
        }

        [HttpGet("echo")]
        public IActionResult Echo(string message = "default")
        {
            return Ok(new { echo = message, timestamp = DateTime.UtcNow });
        }
    }
}
