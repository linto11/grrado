using ChatbotService.Application.UseCases.ChatbotConversations.CreateChatbotConversation;
using ChatbotService.Application.UseCases.ChatbotConversations.DeleteChatbotConversation;
using ChatbotService.Application.UseCases.ChatbotConversations.GetAllChatbotConversations;
using ChatbotService.Application.UseCases.ChatbotConversations.GetChatbotConversationById;
using ChatbotService.Application.UseCases.ChatbotConversations.UpdateChatbotConversation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ChatbotService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChatbotConversationsController : ControllerBase
{
    private readonly IMediator _mediator;
    public ChatbotConversationsController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int skip = 0, [FromQuery] int take = 10)
    { var r = await _mediator.Send(new GetAllChatbotConversationsQuery { Skip = skip, Take = take }); return r.IsSuccess ? Ok(r.Value) : BadRequest(r.Error); }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    { var r = await _mediator.Send(new GetChatbotConversationByIdQuery(id)); return r.IsSuccess ? Ok(r.Value) : NotFound(r.Error); }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateChatbotConversationCommand cmd)
    { var r = await _mediator.Send(cmd); return r.IsSuccess ? CreatedAtAction(nameof(GetById), new { id = r.Value!.Id }, r.Value) : BadRequest(r.Error); }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateChatbotConversationCommand cmd)
    { cmd.Id = id; var r = await _mediator.Send(cmd); return r.IsSuccess ? Ok(r.Value) : NotFound(r.Error); }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    { var r = await _mediator.Send(new DeleteChatbotConversationCommand(id)); return r.IsSuccess ? NoContent() : NotFound(r.Error); }
}
