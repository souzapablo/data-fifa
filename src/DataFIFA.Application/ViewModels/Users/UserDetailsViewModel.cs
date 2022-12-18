using DataFIFA.Application.ViewModels.Careers;
using DataFIFA.Core.Entities;

namespace DataFIFA.Application.ViewModels.Users;

public record UserDetailsViewModel(Guid Id, string Name, string Email, List<CareerViewModel> Careers);