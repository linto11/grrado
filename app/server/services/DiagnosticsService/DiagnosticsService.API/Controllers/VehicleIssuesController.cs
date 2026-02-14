using MediatR;
using Microsoft.AspNetCore.Mvc;
using DiagnosticsService.Application.UseCases.VehicleIssues.CreateVehicleIssue;
using DiagnosticsService.Application.UseCases.VehicleIssues.DeleteVehicleIssue;
using DiagnosticsService.Application.UseCases.VehicleIssues.GetAllVehicleIssues;
using DiagnosticsService.Application.UseCases.VehicleIssues.GetVehicleIssueById;
using DiagnosticsService.Application.UseCases.VehicleIssues.UpdateVehicleIssue;

namespace DiagnosticsService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VehicleIssuesController : ControllerBase
{
    private readonly IMediator _mediator;
    public VehicleIssuesController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        var result = await _mediator.Send(new GetAllVehicleIssuesQuery { Skip = skip, Take = take });
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediator.Send(new GetVehicleIssueByIdQuery(id));
        return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateVehicleIssueCommand command)
    {
        var result = await _mediator.Send(command);
        return result.IsSuccess ? CreatedAtAction(nameof(GetById), new { id = result.Value!.Id }, result.Value) : BadRequest(result.Error);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateVehicleIssueCommand command)
    {
        command.Id = id;
        var result = await _mediator.Send(command);
        return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new DeleteVehicleIssueCommand(id));
        return result.IsSuccess ? NoContent() : NotFound(result.Error);
    }
}
