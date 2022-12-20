using DataFIFA.Application.ViewModels.Players;

namespace DataFIFA.Application.ViewModels.Teams;

public record TeamDetailsVIewModel(Guid TeamId, Guid CareerId, string Name, string Stadium, List<PlayerViewModel> Players);