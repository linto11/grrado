using ChatbotService.Application.UseCases.AiImageAnalyses.CreateAiImageAnalysis;
using ChatbotService.Application.UseCases.AiImageAnalyses.DeleteAiImageAnalysis;
using ChatbotService.Application.UseCases.AiImageAnalyses.GetAllAiImageAnalyses;
using ChatbotService.Application.UseCases.AiImageAnalyses.GetAiImageAnalysisById;
using ChatbotService.Application.UseCases.AiImageAnalyses.UpdateAiImageAnalysis;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ChatbotService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AiImageAnalysesController : ControllerBase
{
    private readonly IMediator _mediator;
    public AiImageAnalysesController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int skip = 0, [FromQuery] int take = 10)
    { var r = await _mediator.Send(new GetAllAiImageAnalysesQuery { Skip = skip, Take = take }); return r.IsSuccess ? Ok(r.Value) : BadRequest(r.Error); }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    { var r = await _mediator.Send(new GetAiImageAnalysisByIdQuery(id)); return r.IsSuccess ? Ok(r.Value) : NotFound(r.Error); }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAiImageAnalysisCommand cmd)
    { var r = await _mediator.Send(cmd); return r.IsSuccess ? CreatedAtAction(nameof(GetById), new { id = r.Value!.Id }, r.Value) : BadRequest(r.Error); }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateAiImageAnalysisCommand cmd)
    { cmd.Id = id; var r = await _mediator.Send(cmd); return r.IsSuccess ? Ok(r.Value) : NotFound(r.Error); }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    { var r = await _mediator.Send(new DeleteAiImageAnalysisCommand(id)); return r.IsSuccess ? NoContent() : NotFound(r.Error); }
}
