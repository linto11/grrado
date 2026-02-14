using LoggingService.Application.UseCases.ErrorMessages.CreateErrorMessage;
using LoggingService.Application.UseCases.ErrorMessages.DeleteErrorMessage;
using LoggingService.Application.UseCases.ErrorMessages.GetAllErrorMessages;
using LoggingService.Application.UseCases.ErrorMessages.GetErrorMessageById;
using LoggingService.Application.UseCases.ErrorMessages.UpdateErrorMessage;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LoggingService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ErrorMessagesController : ControllerBase
{
    private readonly IMediator _mediator;
    public ErrorMessagesController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int skip = 0, [FromQuery] int take = 10)
    { var r = await _mediator.Send(new GetAllErrorMessagesQuery { Skip = skip, Take = take }); return r.IsSuccess ? Ok(r.Value) : BadRequest(r.Error); }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    { var r = await _mediator.Send(new GetErrorMessageByIdQuery(id)); return r.IsSuccess ? Ok(r.Value) : NotFound(r.Error); }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateErrorMessageCommand cmd)
    { var r = await _mediator.Send(cmd); return r.IsSuccess ? CreatedAtAction(nameof(GetById), new { id = r.Value!.Id }, r.Value) : BadRequest(r.Error); }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateErrorMessageCommand cmd)
    { cmd.Id = id; var r = await _mediator.Send(cmd); return r.IsSuccess ? Ok(r.Value) : NotFound(r.Error); }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    { var r = await _mediator.Send(new DeleteErrorMessageCommand(id)); return r.IsSuccess ? NoContent() : NotFound(r.Error); }
}
