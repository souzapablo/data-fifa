using DataFIFA.Core.Entities;

namespace DataFIFA.Application.ViewModels.Careers;

public record CareerDetailsViewModel(Guid Id, Guid UserId, string ManagerName, string? CurrentTeam, List<Team>? Teams);