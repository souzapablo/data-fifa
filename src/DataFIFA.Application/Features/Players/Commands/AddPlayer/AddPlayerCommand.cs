using DataFIFA.Application.ViewModels.Players;
using DataFIFA.Core.Enums;
using MediatR;

namespace DataFIFA.Application.Features.Players.Commands.AddPlayer;

public class AddPlayerCommand : IRequest<PlayerDetailsViewModel>
{
    public AddPlayerCommand(Guid teamId, string name, int shirtNumber, Situation situation, Position position, int overall, int age)
    {
        TeamId = teamId;
        Name = name;
        ShirtNumber = shirtNumber;
        Situation = situation;
        Position = position;
        Overall = overall;
        Age = age;
    }
    
    public Guid TeamId { get; private set; }
    public string Name { get; private set; }
    public int ShirtNumber { get; private set; }
    public Situation Situation { get; private set; }
    public Position Position { get; private set; }
    public int Overall { get; private set; }
    public int Age { get; private set; }
    
}