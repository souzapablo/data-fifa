using DataFIFA.Application.ViewModels.Teams;
using MediatR;

namespace DataFIFA.Application.Features.Teams.Commands.AddInitialTeam;

public class AddInitialTeamCommand : IRequest<TeamDetailsViewModel>
{
    public AddInitialTeamCommand(Guid careerId, string initialTeamName)
    {
        CareerId = careerId;
        InitialTeamName = initialTeamName;
    }
    
    public Guid CareerId { get; set; }
    public string InitialTeamName { get; set; }
}