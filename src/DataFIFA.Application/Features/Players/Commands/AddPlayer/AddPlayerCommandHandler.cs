using DataFIFA.Application.ViewModels.Players;
using DataFIFA.Core.Entities;
using DataFIFA.Infrastructure.Persistence.Repositories.Interfaces;
using MediatR;

namespace DataFIFA.Application.Features.Players.Commands.AddPlayer;

public class AddPlayerCommandHandler : IRequestHandler<AddPlayerCommand, PlayerDetailsViewModel>
{
    private readonly IPlayerRepository _playerRepository;

    public AddPlayerCommandHandler(IPlayerRepository playerRepository)
    {
        _playerRepository = playerRepository;
    }
    
    public async Task<PlayerDetailsViewModel> Handle(AddPlayerCommand request, CancellationToken cancellationToken)
    {
        var player = new Player(request.TeamId, request.Name, request.Overall, request.ShirtNumber, request.Situation,
            request.Position, request.Age);

        await _playerRepository.AddAsync(player);

        return new PlayerDetailsViewModel(
            player.Id,
            player.TeamId,
            player.Name,
            player.Overall,
            player.Age,
            player.ShirtNumber,
            player.Position.ToString(),
            player.Situation.ToString());
    }
}