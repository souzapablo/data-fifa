using DataFIFA.API.Controllers.Shared;
using DataFIFA.Application.Features.Players.Queries.GetById;
using DataFIFA.Application.Features.Players.Queries.ListAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DataFIFA.API.Controllers;

[ApiController]
[Route("/api/v1/players")]
public class PlayersController : BaseController
{
    private readonly IMediator _mediator;

    public PlayersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> ListPlayersAsync()
    {
        var query = new ListAllPlayersQuery();
        var result = await _mediator.Send(query);

        return CustomResponse(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetPlayerByIdAsync(Guid id)
    {
        var query = new GetPlayerByIdQuery(id);
        var result = await _mediator.Send(query);

        return CustomResponse(result);
    }
}