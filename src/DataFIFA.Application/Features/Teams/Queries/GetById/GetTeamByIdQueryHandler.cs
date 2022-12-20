using System.Net;
using DataFIFA.Application.ViewModels.Players;
using DataFIFA.Application.ViewModels.Teams;
using DataFIFA.Core.Constants;
using DataFIFA.Core.Helpers;
using DataFIFA.Core.Helpers.Interfaces;
using DataFIFA.Infrastructure.Persistence.Repositories.Interfaces;
using MediatR;

namespace DataFIFA.Application.Features.Teams.Queries.GetById;

public class GetTeamByIdQueryHandler : IRequestHandler<GetTeamByIdQuery, TeamDetailsVIewModel?>
{
    private readonly ITeamRepository _teamRepository;
    private readonly IMessageHandler _messageHandler;

    public GetTeamByIdQueryHandler(ITeamRepository teamRepository, IMessageHandler messageHandler)
    {
        _teamRepository = teamRepository;
        _messageHandler = messageHandler;
    }
    
    public async Task<TeamDetailsVIewModel?> Handle(GetTeamByIdQuery request, CancellationToken cancellationToken)
    {
        var team = await _teamRepository.GetByIdAsync(request.TeamId, x => x.Players);

        if (team is null)
        {
            _messageHandler.AddMessage(new ErrorMessage(HttpStatusCode.NotFound,    
                ErrorConstants.EntityNotFound("Team", request.TeamId)));
            return null;
        }

        return new TeamDetailsVIewModel(
            team.Id,
            team.CareerId,
            team.Name,
            team.Stadium,
            team.Players.Select(x => new PlayerDetailsViewModel(
                x.Id,
                x.TeamId,
                x.Name,
                x.Overall,
                x.Age,
                x.ShirtNumber,
                x.Position.ToString())).ToList());
    }
}