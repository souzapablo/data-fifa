using DataFIFA.API.Controllers.Shared;
using DataFIFA.Application.Features.Teams.Commands.AddInitialTeam;
using DataFIFA.Application.Features.Teams.Commands.AddTeam;
using DataFIFA.Application.Features.Teams.Queries.GetById;
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
    public async Task<IActionResult> ListTeamsAsync()
    {
        var query = new ListAllTeamsQuery();
        var result = await _mediator.Send(query);

        return CustomResponse(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetTeamByIdAsync(Guid id)
    {
        var query = new GetTeamByIdQuery(id);
        var result = await _mediator.Send(query);

        return CustomResponse(result);
    }

    [HttpPost]
    public async Task<IActionResult> AddTeamAsync(AddTeamInputModel input)
    {
        var command = new AddTeamCommand(input.CareerId, input.Name, input.Stadium);
        var result = await _mediator.Send(command);

        return CustomResponse(result);
    }

    [HttpPost("initial-team")]
    public async Task<IActionResult> AddInitialTeam(AddInitialTeamInputModel input)
    {
        var command = new AddInitialTeamCommand(input.CareerId, input.InitialTeamName);
        var result = await _mediator.Send(command);

        return CustomResponse(result);
    }
}