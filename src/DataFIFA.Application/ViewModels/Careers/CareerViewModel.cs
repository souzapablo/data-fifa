namespace DataFIFA.Application.ViewModels.Careers;

public record CareerViewModel(Guid Id, Guid UserId, string ManagerName, DateTime LastUpdate, string? CurrentTeam);