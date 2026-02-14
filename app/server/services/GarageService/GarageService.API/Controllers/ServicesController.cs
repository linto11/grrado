using MediatR;
using Microsoft.AspNetCore.Mvc;
using GarageService.Application.UseCases.Services.CreateService;
using GarageService.Application.UseCases.Services.DeleteService;
using GarageService.Application.UseCases.Services.GetAllServices;
using GarageService.Application.UseCases.Services.GetServiceById;
using GarageService.Application.UseCases.Services.UpdateService;

namespace GarageService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServicesController : ControllerBase
{
    private readonly IMediator _mediator;
    public ServicesController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        var result = await _mediator.Send(new GetAllServicesQuery { Skip = skip, Take = take });
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediator.Send(new GetServiceByIdQuery(id));
        return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateServiceCommand command)
    {
        var result = await _mediator.Send(command);
        return result.IsSuccess ? CreatedAtAction(nameof(GetById), new { id = result.Value!.Id }, result.Value) : BadRequest(result.Error);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateServiceCommand command)
    {
        command.Id = id;
        var result = await _mediator.Send(command);
        return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new DeleteServiceCommand(id));
        return result.IsSuccess ? NoContent() : NotFound(result.Error);
    }
}
