using DataFIFA.Application.ViewModels.Players;
using MediatR;

namespace DataFIFA.Application.Features.Players.Queries.ListAll;

public class ListAllPlayersQuery : IRequest<List<PlayerDetailsViewModel>>
{
    
}