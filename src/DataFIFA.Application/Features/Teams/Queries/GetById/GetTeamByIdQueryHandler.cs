using System.Net;
using DataFIFA.Application.ViewModels.Teams;
using DataFIFA.Core.Exceptions;
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
        var team = await _teamRepository.GetByIdAsync(request.TeamId);

        if (team is null)
        {
            var ex = new NotFoundException("Team", request.TeamId);
            _messageHandler.AddMessage(new ErrorMessage(HttpStatusCode.NotFound, ex.Message));
            return null;
        }

        return new TeamDetailsVIewModel(
            team.Id,
            team.CareerId,
            team.Name,
            team.Stadium);
    }
}