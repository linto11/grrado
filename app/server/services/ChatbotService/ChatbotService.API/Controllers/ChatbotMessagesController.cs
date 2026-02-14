using ChatbotService.Application.UseCases.ChatbotMessages.CreateChatbotMessage;
using ChatbotService.Application.UseCases.ChatbotMessages.DeleteChatbotMessage;
using ChatbotService.Application.UseCases.ChatbotMessages.GetAllChatbotMessages;
using ChatbotService.Application.UseCases.ChatbotMessages.GetChatbotMessageById;
using ChatbotService.Application.UseCases.ChatbotMessages.UpdateChatbotMessage;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ChatbotService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChatbotMessagesController : ControllerBase
{
    private readonly IMediator _mediator;
    public ChatbotMessagesController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int skip = 0, [FromQuery] int take = 10)
    { var r = await _mediator.Send(new GetAllChatbotMessagesQuery { Skip = skip, Take = take }); return r.IsSuccess ? Ok(r.Value) : BadRequest(r.Error); }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    { var r = await _mediator.Send(new GetChatbotMessageByIdQuery(id)); return r.IsSuccess ? Ok(r.Value) : NotFound(r.Error); }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateChatbotMessageCommand cmd)
    { var r = await _mediator.Send(cmd); return r.IsSuccess ? CreatedAtAction(nameof(GetById), new { id = r.Value!.Id }, r.Value) : BadRequest(r.Error); }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateChatbotMessageCommand cmd)
    { cmd.Id = id; var r = await _mediator.Send(cmd); return r.IsSuccess ? Ok(r.Value) : NotFound(r.Error); }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    { var r = await _mediator.Send(new DeleteChatbotMessageCommand(id)); return r.IsSuccess ? NoContent() : NotFound(r.Error); }
}
