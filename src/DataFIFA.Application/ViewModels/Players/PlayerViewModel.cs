namespace DataFIFA.Application.ViewModels.Players;

public record PlayerViewModel(Guid PlayerId, Guid TeamId, string Name, int Overall, int Age, int ShirtNumber, string Position);