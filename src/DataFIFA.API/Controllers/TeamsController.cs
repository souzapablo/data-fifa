using DataFIFA.API.Controllers.Shared;
using DataFIFA.Application.Features.Teams.Queries.ListTeams;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DataFIFA.API.Controllers;

[ApiController]
[Route("/api/v1/teams")]
public class TeamsController : BaseController
{
    private readonly IMediator _mediator;

    public TeamsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> ListAll()
    {
        var query = new ListAllTeamsQuery();
        var result = await _mediator.Send(query);

        return CustomResponse(result);
    }
    
}