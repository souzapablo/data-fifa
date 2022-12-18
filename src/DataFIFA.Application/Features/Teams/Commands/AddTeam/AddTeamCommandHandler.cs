using DataFIFA.Application.ViewModels.Teams;
using DataFIFA.Core.Entities;
using DataFIFA.Infrastructure.Persistence.Repositories.Interfaces;
using MediatR;

namespace DataFIFA.Application.Features.Teams.Commands.AddTeam;

public class AddTeamCommandHandler : IRequestHandler<AddTeamCommand, AddTeamViewModel>
{
    private readonly ITeamRepository _teamRepository;

    public AddTeamCommandHandler(ITeamRepository teamRepository)
    {
        _teamRepository = teamRepository;
    }
    
    public async Task<AddTeamViewModel> Handle(AddTeamCommand request, CancellationToken cancellationToken)
    {
        var team = new Team(request.CareerId, request.Name, request.Stadium);

        await _teamRepository.AddAsync(team);
        
        return new AddTeamViewModel(
            team.Id,
            team.CareerId,
            team.Name,
            team.Stadium);
    }
}