using DataFIFA.Application.ViewModels.Teams;
using MediatR;

namespace DataFIFA.Application.Features.Teams.Queries.ListTeams;

public class ListAllTeamsQuery : IRequest<List<TeamViewModel>>
{
    
}