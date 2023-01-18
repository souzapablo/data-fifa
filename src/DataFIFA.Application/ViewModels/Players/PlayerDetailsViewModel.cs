namespace DataFIFA.Application.ViewModels.Players;

public record PlayerDetailsViewModel(Guid PlayerId, Guid TeamId, string Name, int Overall, int Age, int? KitNumber, string Position, string Situation);