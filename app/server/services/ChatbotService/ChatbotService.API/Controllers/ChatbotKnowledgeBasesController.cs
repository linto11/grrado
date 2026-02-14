using ChatbotService.Application.UseCases.ChatbotKnowledgeBases.CreateChatbotKnowledgeBase;
using ChatbotService.Application.UseCases.ChatbotKnowledgeBases.DeleteChatbotKnowledgeBase;
using ChatbotService.Application.UseCases.ChatbotKnowledgeBases.GetAllChatbotKnowledgeBases;
using ChatbotService.Application.UseCases.ChatbotKnowledgeBases.GetChatbotKnowledgeBaseById;
using ChatbotService.Application.UseCases.ChatbotKnowledgeBases.UpdateChatbotKnowledgeBase;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ChatbotService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChatbotKnowledgeBasesController : ControllerBase
{
    private readonly IMediator _mediator;
    public ChatbotKnowledgeBasesController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int skip = 0, [FromQuery] int take = 10)
    { var r = await _mediator.Send(new GetAllChatbotKnowledgeBasesQuery { Skip = skip, Take = take }); return r.IsSuccess ? Ok(r.Value) : BadRequest(r.Error); }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    { var r = await _mediator.Send(new GetChatbotKnowledgeBaseByIdQuery(id)); return r.IsSuccess ? Ok(r.Value) : NotFound(r.Error); }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateChatbotKnowledgeBaseCommand cmd)
    { var r = await _mediator.Send(cmd); return r.IsSuccess ? CreatedAtAction(nameof(GetById), new { id = r.Value!.Id }, r.Value) : BadRequest(r.Error); }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateChatbotKnowledgeBaseCommand cmd)
    { cmd.Id = id; var r = await _mediator.Send(cmd); return r.IsSuccess ? Ok(r.Value) : NotFound(r.Error); }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    { var r = await _mediator.Send(new DeleteChatbotKnowledgeBaseCommand(id)); return r.IsSuccess ? NoContent() : NotFound(r.Error); }
}
