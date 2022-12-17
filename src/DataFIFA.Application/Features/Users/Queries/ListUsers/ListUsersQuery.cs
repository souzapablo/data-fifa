using DataFIFA.Application.ViewModels.Users;
using MediatR;

namespace DataFIFA.Application.Features.Users.Queries.ListUsers;

public class ListUsersQuery : IRequest<List<UserViewModel>>
{
    
}