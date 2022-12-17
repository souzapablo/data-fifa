using DataFIFA.Application.ViewModels;
using DataFIFA.Infrastructure.Persistence;
using MediatR;

namespace DataFIFA.Application.Features.Users.Queries.ListUsers;

public class ListUsersQueryHandler : IRequestHandler<ListUsersQuery, List<UserViewModel>>
{
    private readonly DataFIFADbContext _dbContext;

    public ListUsersQueryHandler(DataFIFADbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<List<UserViewModel>> Handle(ListUsersQuery request, CancellationToken cancellationToken)
    {
        var users = _dbContext.Users;
        var usersVm = users.Select(x => new UserViewModel
            (x.Name, x.Email)).ToList();
        return Task.FromResult(usersVm);
    }
}