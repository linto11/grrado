using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {
        /// <summary>
        /// Health check endpoint - no database required
        /// </summary>
        [HttpGet("status")]
        public IActionResult HealthStatus()
        {
            return Ok(new
            {
                status = "healthy",
                timestamp = DateTime.UtcNow,
                service = "Vehicle Service API",
                version = "1.0.0"
            });
        }

        /// <summary>
        /// Ready check endpoint
        /// </summary>
        [HttpGet("ready")]
        public IActionResult Ready()
        {
            return Ok(new
            {
                ready = true,
                timestamp = DateTime.UtcNow,
                environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"
            });
        }
    }
}
