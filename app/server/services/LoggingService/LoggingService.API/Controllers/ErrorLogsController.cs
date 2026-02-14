using LoggingService.Application.UseCases.ErrorLogs.CreateErrorLog;
using LoggingService.Application.UseCases.ErrorLogs.DeleteErrorLog;
using LoggingService.Application.UseCases.ErrorLogs.GetAllErrorLogs;
using LoggingService.Application.UseCases.ErrorLogs.GetErrorLogById;
using LoggingService.Application.UseCases.ErrorLogs.UpdateErrorLog;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LoggingService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ErrorLogsController : ControllerBase
{
    private readonly IMediator _mediator;
    public ErrorLogsController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int skip = 0, [FromQuery] int take = 10)
    { var r = await _mediator.Send(new GetAllErrorLogsQuery { Skip = skip, Take = take }); return r.IsSuccess ? Ok(r.Value) : BadRequest(r.Error); }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    { var r = await _mediator.Send(new GetErrorLogByIdQuery(id)); return r.IsSuccess ? Ok(r.Value) : NotFound(r.Error); }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateErrorLogCommand cmd)
    { var r = await _mediator.Send(cmd); return r.IsSuccess ? CreatedAtAction(nameof(GetById), new { id = r.Value!.Id }, r.Value) : BadRequest(r.Error); }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateErrorLogCommand cmd)
    { cmd.Id = id; var r = await _mediator.Send(cmd); return r.IsSuccess ? Ok(r.Value) : NotFound(r.Error); }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    { var r = await _mediator.Send(new DeleteErrorLogCommand(id)); return r.IsSuccess ? NoContent() : NotFound(r.Error); }
}
