using System.Net;
using DataFIFA.Application.ViewModels.Players;
using DataFIFA.Core.Constants;
using DataFIFA.Core.Helpers;
using DataFIFA.Core.Helpers.Interfaces;
using DataFIFA.Infrastructure.Persistence.Repositories.Interfaces;
using MediatR;

namespace DataFIFA.Application.Features.Players.Queries.GetById;

public class GetPlayerByIdQueryHandler : IRequestHandler<GetPlayerByIdQuery, PlayerDetailsViewModel?>
{
    private readonly IPlayerRepository _playerRepository;
    private readonly IMessageHandler _messageHandler;

    public GetPlayerByIdQueryHandler(IPlayerRepository playerRepository, IMessageHandler messageHandler)
    {
        _playerRepository = playerRepository;
        _messageHandler = messageHandler;
    }

    public async Task<PlayerDetailsViewModel?> Handle(GetPlayerByIdQuery request, CancellationToken cancellationToken)
    {
        var player = await _playerRepository.GetByIdAsync(request.PlayerId);

        if (player is null)
        {
            _messageHandler.AddMessage(new ErrorMessage(HttpStatusCode.NotFound, 
                ErrorConstants.EntityNotFound("Player", request.PlayerId)));
            return null;
        }

        return new PlayerDetailsViewModel(
            player.Id,
            player.TeamId,
            player.Name,
            player.Overall,
            player.Age,
            player.ShirtNumber,
            player.Position.ToString());
    }
}