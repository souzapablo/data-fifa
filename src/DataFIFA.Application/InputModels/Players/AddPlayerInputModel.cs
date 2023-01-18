using DataFIFA.Core.Enums;

namespace DataFIFA.Application.InputModels.Players;

public record AddPlayerInputModel(Guid TeamId, string FirstName, string LastName, int KitNumber, Situation Situation, Position Position, int Overall, int Age);
