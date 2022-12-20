using DataFIFA.Application.ViewModels.Careers;

namespace DataFIFA.Application.ViewModels.Users;

public record UserDetailsViewModel(Guid Id, string Name, string Email, List<CareerViewModel> Careers);