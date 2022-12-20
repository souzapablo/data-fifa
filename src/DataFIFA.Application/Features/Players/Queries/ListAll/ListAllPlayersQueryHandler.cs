using DataFIFA.Application.ViewModels.Players;
using DataFIFA.Infrastructure.Persistence.Repositories.Interfaces;
using MediatR;

namespace DataFIFA.Application.Features.Players.Queries.ListAll;

public class ListAllPlayersQueryHandler : IRequestHandler<ListAllPlayersQuery, List<PlayerDetailsViewModel>>
{
    private readonly IPlayerRepository _playerRepository;

    public ListAllPlayersQueryHandler(IPlayerRepository playerRepository)
    {
        _playerRepository = playerRepository;
    }
    
    public async Task<List<PlayerDetailsViewModel>> Handle(ListAllPlayersQuery request, CancellationToken cancellationToken)
    {
        var players = await _playerRepository.ListAllAsync();

        return players.Select(x => new PlayerDetailsViewModel(
            x.Id,
            x.TeamId, 
            x.Name,
            x.Overall,
            x.Age,
            x.ShirtNumber,
            x.Position.ToString())).ToList();
    }
}