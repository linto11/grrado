using Abstractions.DTOs.AiImageAnalysis;
using Application.Services.Chatbot;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Chatbot;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class AiImageAnalysesController : ControllerBase
{
    private readonly IAiImageAnalysisService _service;
    private readonly ILogger<AiImageAnalysesController> _logger;

    public AiImageAnalysesController(IAiImageAnalysisService service, ILogger<AiImageAnalysesController> logger)
    {
        _service = service;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<List<AiImageAnalysisDto>>> GetAll([FromQuery] int skip = 0, [FromQuery] int take = 10, CancellationToken cancellationToken = default)
    {
        var result = await _service.GetAllAsync(skip, take, cancellationToken);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AiImageAnalysisDto>> GetById(int id, CancellationToken cancellationToken = default)
    {
        var result = await _service.GetByIdAsync(id, cancellationToken);
        return result == null ? NotFound() : Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<AiImageAnalysisDto>> Create([FromBody] CreateAiImageAnalysisRequest request, CancellationToken cancellationToken = default)
    {
        var result = await _service.CreateAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<AiImageAnalysisDto>> Update(int id, [FromBody] UpdateAiImageAnalysisRequest request, CancellationToken cancellationToken = default)
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
