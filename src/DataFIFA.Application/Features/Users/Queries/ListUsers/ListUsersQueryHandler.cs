using DataFIFA.Application.ViewModels.Users;
using DataFIFA.Infrastructure.Persistence.Repositories.Interfaces;
using MediatR;

namespace DataFIFA.Application.Features.Users.Queries.ListUsers;

public class ListUsersQueryHandler : IRequestHandler<ListUsersQuery, List<UserViewModel>>
{
    private readonly IUserRepository _userRepository;

    public ListUsersQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<List<UserViewModel>> Handle(ListUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.ListAllAsync();
        
        return users.Select(x => new UserViewModel(x.Id, x.Name, x.Email)).ToList();
    }
}