using MediatR;
using Microsoft.AspNetCore.Mvc;
using ServiceHistoryService.Application.UseCases.ServiceHistories.CreateServiceHistory;
using ServiceHistoryService.Application.UseCases.ServiceHistories.DeleteServiceHistory;
using ServiceHistoryService.Application.UseCases.ServiceHistories.GetAllServiceHistories;
using ServiceHistoryService.Application.UseCases.ServiceHistories.GetServiceHistoryById;
using ServiceHistoryService.Application.UseCases.ServiceHistories.UpdateServiceHistory;

namespace ServiceHistoryService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServiceHistoriesController : ControllerBase
{
    private readonly IMediator _mediator;
    public ServiceHistoriesController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        var result = await _mediator.Send(new GetAllServiceHistoriesQuery { Skip = skip, Take = take });
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediator.Send(new GetServiceHistoryByIdQuery(id));
        return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateServiceHistoryCommand command)
    {
        var result = await _mediator.Send(command);
        return result.IsSuccess ? CreatedAtAction(nameof(GetById), new { id = result.Value!.Id }, result.Value) : BadRequest(result.Error);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateServiceHistoryCommand command)
    {
        command.Id = id;
        var result = await _mediator.Send(command);
        return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new DeleteServiceHistoryCommand(id));
        return result.IsSuccess ? NoContent() : NotFound(result.Error);
    }
}
