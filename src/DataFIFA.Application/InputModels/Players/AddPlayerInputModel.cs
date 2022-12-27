using DataFIFA.Core.Enums;

namespace DataFIFA.Application.InputModels.Players;

public record AddPlayerInputModel(Guid TeamId, string FirstName, string LastName, int ShirtNumber, Situation Situation, Position Position, int Overall, int Age);
