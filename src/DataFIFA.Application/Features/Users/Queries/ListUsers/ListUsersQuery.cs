using DataFIFA.Application.ViewModels;
using MediatR;

namespace DataFIFA.Application.Features.Users.Queries.ListUsers;

public class ListUsersQuery : IRequest<List<UserViewModel>>
{
    
}