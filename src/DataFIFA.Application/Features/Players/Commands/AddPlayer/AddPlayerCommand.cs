using DataFIFA.Application.ViewModels.Players;
using DataFIFA.Core.Enums;
using MediatR;

namespace DataFIFA.Application.Features.Players.Commands.AddPlayer;

public class AddPlayerCommand : IRequest<PlayerDetailsViewModel>
{
    public AddPlayerCommand(Guid teamId, string firstName, string lastName, int shirtNumber, Situation situation, Position position, int overall, int age)
    {
        TeamId = teamId;
        FirstName = firstName;
        LastName = lastName;
        ShirtNumber = shirtNumber;
        Situation = situation;
        Position = position;
        Overall = overall;
        Age = age;
    }
    
    public Guid TeamId { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public int ShirtNumber { get; private set; }
    public Situation Situation { get; private set; }
    public Position Position { get; private set; }
    public int Overall { get; private set; }
    public int Age { get; private set; }
    
}