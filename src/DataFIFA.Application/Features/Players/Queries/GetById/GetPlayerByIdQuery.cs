using DataFIFA.Application.ViewModels.Players;
using MediatR;

namespace DataFIFA.Application.Features.Players.Queries.GetById;

public class GetPlayerByIdQuery : IRequest<PlayerDetailsViewModel?>
{
    public GetPlayerByIdQuery(Guid playerId)
    {
        PlayerId = playerId;
    }
    
    public Guid PlayerId { get; private set; }
}