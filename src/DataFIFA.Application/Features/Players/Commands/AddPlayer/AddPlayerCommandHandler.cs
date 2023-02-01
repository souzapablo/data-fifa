using DataFIFA.Application.Validators.Players;
using DataFIFA.Application.ViewModels.Players;
using DataFIFA.Core.Entities;
using DataFIFA.Core.Helpers.Interfaces;
using DataFIFA.Infrastructure.Persistence.Repositories.Interfaces;
using MediatR;

namespace DataFIFA.Application.Features.Players.Commands.AddPlayer;

public class AddPlayerCommandHandler : IRequestHandler<AddPlayerCommand, PlayerDetailsViewModel?>
{
    private readonly IPlayerRepository _playerRepository;
    private readonly IMessageHandler _messageHandler;

    public AddPlayerCommandHandler(IPlayerRepository playerRepository, IMessageHandler messageHandler)
    {
        _playerRepository = playerRepository;
        _messageHandler = messageHandler;
    }
    
    public async Task<PlayerDetailsViewModel?> Handle(AddPlayerCommand request, CancellationToken cancellationToken)
    {
        var validationErrors = new AddPlayerCommandValidator().ListErrors(request);

        if (validationErrors.Any())
        {
            _messageHandler.AddRangeMessages(validationErrors);
            return null;
        }

        var player = new Player(request.TeamId, request.FirstName, request.LastName, request.Overall, request.KitNumber, request.Situation,
            request.Position, request.Age);

        await _playerRepository.AddAsync(player);

        return new PlayerDetailsViewModel(
            player.Id,
            player.TeamId,
            $"{player.FirstName} {player.LastName}",
            player.Overall,
            player.Age,
            player.KitNumber,
            player.Position.ToString(),
            player.Situation.ToString());
    }
}