using Abstractions.DTOs.ServiceHistory;
using Application.Services.ServiceHistories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.ServiceHistories;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class ServiceHistoriesController : ControllerBase
{
    private readonly IServiceHistoryService _service;
    private readonly ILogger<ServiceHistoriesController> _logger;

    public ServiceHistoriesController(IServiceHistoryService service, ILogger<ServiceHistoriesController> logger)
    {
        _service = service;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<List<ServiceHistoryDto>>> GetAll([FromQuery] int skip = 0, [FromQuery] int take = 10, CancellationToken cancellationToken = default)
    {
        var result = await _service.GetAllAsync(skip, take, cancellationToken);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceHistoryDto>> GetById(int id, CancellationToken cancellationToken = default)
    {
        var result = await _service.GetByIdAsync(id, cancellationToken);
        return result == null ? NotFound() : Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<ServiceHistoryDto>> Create([FromBody] CreateServiceHistoryRequest request, CancellationToken cancellationToken = default)
    {
        var result = await _service.CreateAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ServiceHistoryDto>> Update(int id, [FromBody] UpdateServiceHistoryRequest request, CancellationToken cancellationToken = default)
    {
        try
        {
            var result = await _service.UpdateAsync(id, request, cancellationToken);
            return Ok(result);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id, CancellationToken cancellationToken = default)
    {
        try
        {
            var userId = User.FindFirst("sub")?.Value ?? "system";
            await _service.DeleteAsync(id, userId, cancellationToken);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
}
