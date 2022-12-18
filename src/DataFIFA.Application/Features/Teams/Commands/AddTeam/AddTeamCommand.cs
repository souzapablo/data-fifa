using DataFIFA.Application.ViewModels.Teams;
using MediatR;

namespace DataFIFA.Application.Features.Teams.Commands.AddTeam;

public class AddTeamCommand : IRequest<AddTeamViewModel>
{
    public AddTeamCommand(Guid careerId, string name, string stadium)
    {
        CareerId = careerId;
        Name = name;
        Stadium = stadium;
    }
    
    public Guid CareerId { get; set; }
    public string Name { get; private set; }
    public string Stadium { get; private set; }
}