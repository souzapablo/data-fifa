using DataFIFA.Application.ViewModels.Teams;
using DataFIFA.Infrastructure.Persistence.Repositories.Interfaces;
using MediatR;

namespace DataFIFA.Application.Features.Teams.Queries.ListTeams;

public class ListAllTeamsQueryHandler : IRequestHandler<ListAllTeamsQuery, List<TeamViewModel>>
{
    private readonly ITeamRepository _teamRepository;

    public ListAllTeamsQueryHandler(ITeamRepository teamRepository)
    {
        _teamRepository = teamRepository;
    }
    
    public async Task<List<TeamViewModel>> Handle(ListAllTeamsQuery request, CancellationToken cancellationToken)
    {
        var teams = await _teamRepository.ListAllAsync();

        return teams.Select(x => new TeamViewModel(
            x.Id,
            x.CareerId,
            x.Name, 
            x.Stadium)).ToList();
    }
}