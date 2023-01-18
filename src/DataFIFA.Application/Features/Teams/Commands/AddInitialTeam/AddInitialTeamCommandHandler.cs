using DataFIFA.Application.ViewModels.Players;
using DataFIFA.Application.ViewModels.Teams;
using DataFIFA.Core.Entities;
using DataFIFA.Core.Helpers.Files.InitialTeams;
using DataFIFA.Infrastructure.Persistence.Repositories.Interfaces;
using MediatR;
using Newtonsoft.Json;

namespace DataFIFA.Application.Features.Teams.Commands.AddInitialTeam;

public class AddInitialTeamCommandHandler : IRequestHandler<AddInitialTeamCommand, TeamDetailsViewModel>
{
    private readonly ITeamRepository _teamRepository;
    private readonly IPlayerRepository _playerRepository;

    public AddInitialTeamCommandHandler(ITeamRepository teamRepository, IPlayerRepository playerRepository)
    {
        _teamRepository = teamRepository;
        _playerRepository = playerRepository;
    }
    
    public async Task<TeamDetailsViewModel> Handle(AddInitialTeamCommand request, CancellationToken cancellationToken)
    {
        var json = await GetInitialTeamJson(request.InitialTeamName);

        var initialTeam = JsonConvert.DeserializeObject<InitialTeam>(json);

        var team = new Team(request.CareerId, initialTeam.Name, initialTeam.Stadium);

        await _teamRepository.AddAsync(team);

        var lineUp = initialTeam.LineUp.Select(player => 
            new Player(
                team.Id, 
                player.FirstName, 
                player.LastName, 
                player.Overall, 
                player.KitNumber, 
                player.Situation, 
                player.Position, 
                player.Age)).ToList();

        await _playerRepository.AddLineUpAsync(lineUp);
        
        return new TeamDetailsViewModel(
            team.Id, 
            team.CareerId,
            team.Name, 
            team.Stadium,
            team.Players.Select(x => new PlayerDetailsViewModel(
                x.Id,
                x.TeamId,
                $"{x.FirstName} {x.LastName}",
                x.Overall,
                x.Age,
                x.KitNumber,
                x.Position.ToString(),
                x.Situation.ToString())).ToList());
    }

    private static async Task<string> GetInitialTeamJson(string initialTeamName)
    {
        using StreamReader r = new($"./../DataFIFA.Core/Helpers/Files/InitialTeams/{initialTeamName}.json");

        return await r.ReadToEndAsync();
    }
}