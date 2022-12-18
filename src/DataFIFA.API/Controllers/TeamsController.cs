using DataFIFA.API.Controllers.Shared;
using DataFIFA.Application.Features.Teams.Commands.AddTeam;
using DataFIFA.Application.Features.Teams.Queries.ListTeams;
using DataFIFA.Application.InputModels.Teams;
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

    [HttpPost]
    public async Task<IActionResult> AddTeam(AddTeamInputModel input)
    {
        var command = new AddTeamCommand(input.CareerId, input.Name, input.Stadium);
        var result = await _mediator.Send(command);

        return CustomResponse(result);
    }
    
}