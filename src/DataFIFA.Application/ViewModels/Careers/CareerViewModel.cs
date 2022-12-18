using DataFIFA.Core.Entities;

namespace DataFIFA.Application.ViewModels.Careers;

public record CareerViewModel(Guid Id, Guid UserId, string ManagerName, List<Team> Teams);