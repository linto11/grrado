using MediatR;
using Microsoft.AspNetCore.Mvc;
using DiagnosticsService.Application.UseCases.ImageDiagnostics.CreateImageDiagnostic;
using DiagnosticsService.Application.UseCases.ImageDiagnostics.DeleteImageDiagnostic;
using DiagnosticsService.Application.UseCases.ImageDiagnostics.GetAllImageDiagnostics;
using DiagnosticsService.Application.UseCases.ImageDiagnostics.GetImageDiagnosticById;
using DiagnosticsService.Application.UseCases.ImageDiagnostics.UpdateImageDiagnostic;

namespace DiagnosticsService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ImageDiagnosticsController : ControllerBase
{
    private readonly IMediator _mediator;
    public ImageDiagnosticsController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        var result = await _mediator.Send(new GetAllImageDiagnosticsQuery { Skip = skip, Take = take });
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediator.Send(new GetImageDiagnosticByIdQuery(id));
        return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateImageDiagnosticCommand command)
    {
        var result = await _mediator.Send(command);
        return result.IsSuccess ? CreatedAtAction(nameof(GetById), new { id = result.Value!.Id }, result.Value) : BadRequest(result.Error);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateImageDiagnosticCommand command)
    {
        command.Id = id;
        var result = await _mediator.Send(command);
        return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new DeleteImageDiagnosticCommand(id));
        return result.IsSuccess ? NoContent() : NotFound(result.Error);
    }
}
