using BuberDinner.Application.Menus.Commands.CreateMenu;
using BuberDinner.Contracts.Menus;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[Route("hosts/{hostId}/menus")]
public class MenusController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;
    public MenusController(IMapper mapper, ISender mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateMenuAsync(CreateMenuRequest request, string hostId)
    {
        var command = _mapper.Map<CreateMenuCommand>((request, hostId));
        var createMenuResult = await _mediator.Send(command);

        return createMenuResult.Match(
            menu => Ok(_mapper.Map<MenuResponse>(menu)),
            errors => Problem(errors))
            ;
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetMenu(Guid id)
    {
        return Ok();
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateMenu(Guid id, UpdateMenuRequest request)
    {
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteMenu(Guid id)
    {
        return Ok();
    }
}
