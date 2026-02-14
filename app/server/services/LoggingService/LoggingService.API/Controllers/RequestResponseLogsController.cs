using LoggingService.Application.UseCases.RequestResponseLogs.CreateRequestResponseLog;
using LoggingService.Application.UseCases.RequestResponseLogs.DeleteRequestResponseLog;
using LoggingService.Application.UseCases.RequestResponseLogs.GetAllRequestResponseLogs;
using LoggingService.Application.UseCases.RequestResponseLogs.GetRequestResponseLogById;
using LoggingService.Application.UseCases.RequestResponseLogs.UpdateRequestResponseLog;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LoggingService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RequestResponseLogsController : ControllerBase
{
    private readonly IMediator _mediator;
    public RequestResponseLogsController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int skip = 0, [FromQuery] int take = 10)
    { var r = await _mediator.Send(new GetAllRequestResponseLogsQuery { Skip = skip, Take = take }); return r.IsSuccess ? Ok(r.Value) : BadRequest(r.Error); }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    { var r = await _mediator.Send(new GetRequestResponseLogByIdQuery(id)); return r.IsSuccess ? Ok(r.Value) : NotFound(r.Error); }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateRequestResponseLogCommand cmd)
    { var r = await _mediator.Send(cmd); return r.IsSuccess ? CreatedAtAction(nameof(GetById), new { id = r.Value!.Id }, r.Value) : BadRequest(r.Error); }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateRequestResponseLogCommand cmd)
    { cmd.Id = id; var r = await _mediator.Send(cmd); return r.IsSuccess ? Ok(r.Value) : NotFound(r.Error); }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    { var r = await _mediator.Send(new DeleteRequestResponseLogCommand(id)); return r.IsSuccess ? NoContent() : NotFound(r.Error); }
}
