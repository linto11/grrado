using ChatbotService.Application.UseCases.AiUsageLogs.CreateAiUsageLog;
using ChatbotService.Application.UseCases.AiUsageLogs.DeleteAiUsageLog;
using ChatbotService.Application.UseCases.AiUsageLogs.GetAllAiUsageLogs;
using ChatbotService.Application.UseCases.AiUsageLogs.GetAiUsageLogById;
using ChatbotService.Application.UseCases.AiUsageLogs.UpdateAiUsageLog;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ChatbotService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AiUsageLogsController : ControllerBase
{
    private readonly IMediator _mediator;
    public AiUsageLogsController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int skip = 0, [FromQuery] int take = 10)
    { var r = await _mediator.Send(new GetAllAiUsageLogsQuery { Skip = skip, Take = take }); return r.IsSuccess ? Ok(r.Value) : BadRequest(r.Error); }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    { var r = await _mediator.Send(new GetAiUsageLogByIdQuery(id)); return r.IsSuccess ? Ok(r.Value) : NotFound(r.Error); }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAiUsageLogCommand cmd)
    { var r = await _mediator.Send(cmd); return r.IsSuccess ? CreatedAtAction(nameof(GetById), new { id = r.Value!.Id }, r.Value) : BadRequest(r.Error); }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateAiUsageLogCommand cmd)
    { cmd.Id = id; var r = await _mediator.Send(cmd); return r.IsSuccess ? Ok(r.Value) : NotFound(r.Error); }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    { var r = await _mediator.Send(new DeleteAiUsageLogCommand(id)); return r.IsSuccess ? NoContent() : NotFound(r.Error); }
}
