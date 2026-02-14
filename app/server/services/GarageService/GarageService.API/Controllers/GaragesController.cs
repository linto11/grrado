using MediatR;
using Microsoft.AspNetCore.Mvc;
using GarageService.Application.UseCases.Garages.CreateGarage;
using GarageService.Application.UseCases.Garages.DeleteGarage;
using GarageService.Application.UseCases.Garages.GetAllGarages;
using GarageService.Application.UseCases.Garages.GetGarageById;
using GarageService.Application.UseCases.Garages.UpdateGarage;

namespace GarageService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GaragesController : ControllerBase
{
    private readonly IMediator _mediator;
    public GaragesController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        var result = await _mediator.Send(new GetAllGaragesQuery { Skip = skip, Take = take });
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediator.Send(new GetGarageByIdQuery(id));
        return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateGarageCommand command)
    {
        var result = await _mediator.Send(command);
        return result.IsSuccess ? CreatedAtAction(nameof(GetById), new { id = result.Value!.Id }, result.Value) : BadRequest(result.Error);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateGarageCommand command)
    {
        command.Id = id;
        var result = await _mediator.Send(command);
        return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new DeleteGarageCommand(id));
        return result.IsSuccess ? NoContent() : NotFound(result.Error);
    }
}
