using MediatR;
using Microsoft.AspNetCore.Mvc;
using DiagnosticsService.Application.UseCases.DiagnosticRules.CreateDiagnosticRule;
using DiagnosticsService.Application.UseCases.DiagnosticRules.DeleteDiagnosticRule;
using DiagnosticsService.Application.UseCases.DiagnosticRules.GetAllDiagnosticRules;
using DiagnosticsService.Application.UseCases.DiagnosticRules.GetDiagnosticRuleById;
using DiagnosticsService.Application.UseCases.DiagnosticRules.UpdateDiagnosticRule;

namespace DiagnosticsService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DiagnosticRulesController : ControllerBase
{
    private readonly IMediator _mediator;
    public DiagnosticRulesController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        var result = await _mediator.Send(new GetAllDiagnosticRulesQuery { Skip = skip, Take = take });
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediator.Send(new GetDiagnosticRuleByIdQuery(id));
        return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateDiagnosticRuleCommand command)
    {
        var result = await _mediator.Send(command);
        return result.IsSuccess ? CreatedAtAction(nameof(GetById), new { id = result.Value!.Id }, result.Value) : BadRequest(result.Error);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateDiagnosticRuleCommand command)
    {
        command.Id = id;
        var result = await _mediator.Send(command);
        return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new DeleteDiagnosticRuleCommand(id));
        return result.IsSuccess ? NoContent() : NotFound(result.Error);
    }
}
