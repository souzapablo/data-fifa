using DataFIFA.Application.ViewModels.Users;
using MediatR;

namespace DataFIFA.Application.Features.Users.Queries.GetUserById;

public class GetUserByIdQuery : IRequest<UserDetailsViewModel?>
{
    public GetUserByIdQuery(Guid userId)
    {
        UserId = userId;
    }
    
    public Guid UserId { get; set; }
}