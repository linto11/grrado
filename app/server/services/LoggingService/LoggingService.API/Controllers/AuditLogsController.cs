using LoggingService.Application.UseCases.AuditLogs.CreateAuditLog;
using LoggingService.Application.UseCases.AuditLogs.DeleteAuditLog;
using LoggingService.Application.UseCases.AuditLogs.GetAllAuditLogs;
using LoggingService.Application.UseCases.AuditLogs.GetAuditLogById;
using LoggingService.Application.UseCases.AuditLogs.UpdateAuditLog;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LoggingService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuditLogsController : ControllerBase
{
    private readonly IMediator _mediator;
    public AuditLogsController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int skip = 0, [FromQuery] int take = 10)
    { var r = await _mediator.Send(new GetAllAuditLogsQuery { Skip = skip, Take = take }); return r.IsSuccess ? Ok(r.Value) : BadRequest(r.Error); }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    { var r = await _mediator.Send(new GetAuditLogByIdQuery(id)); return r.IsSuccess ? Ok(r.Value) : NotFound(r.Error); }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAuditLogCommand cmd)
    { var r = await _mediator.Send(cmd); return r.IsSuccess ? CreatedAtAction(nameof(GetById), new { id = r.Value!.Id }, r.Value) : BadRequest(r.Error); }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateAuditLogCommand cmd)
    { cmd.Id = id; var r = await _mediator.Send(cmd); return r.IsSuccess ? Ok(r.Value) : NotFound(r.Error); }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    { var r = await _mediator.Send(new DeleteAuditLogCommand(id)); return r.IsSuccess ? NoContent() : NotFound(r.Error); }
}
