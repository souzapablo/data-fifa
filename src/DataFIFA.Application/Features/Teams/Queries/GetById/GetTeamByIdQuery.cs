using DataFIFA.Application.ViewModels.Teams;
using MediatR;

namespace DataFIFA.Application.Features.Teams.Queries.GetById;

public class GetTeamByIdQuery : IRequest<TeamDetailsVIewModel?>
{
    public GetTeamByIdQuery(Guid teamId)
    {
        TeamId = teamId;
    }
    
    public Guid TeamId { get; private set; }
}