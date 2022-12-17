using DataFIFA.Core.Entities;

namespace DataFIFA.Application.ViewModels.Users;

public record UserDetailsViewModel(string Name, string Email, List<Career> Careers);