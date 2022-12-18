using DataFIFA.Application.ViewModels.Users;
using DataFIFA.Core.Entities;
using DataFIFA.Infrastructure.Persistence.Repositories.Interfaces;
using MediatR;

namespace DataFIFA.Application.Features.Users.Queries.GetUserById;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDetailsViewModel?>
{
    private readonly IUserRepository _userRepository;

    public GetUserByIdQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<UserDetailsViewModel?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId);

        return user is null 
            ? null 
            : new UserDetailsViewModel(user.Id, user.Email, user.Name, new List<Career>());
    }
}