using System.Net;
using DataFIFA.Application.ViewModels.Careers;
using DataFIFA.Application.ViewModels.Users;
using DataFIFA.Core.Entities;
using DataFIFA.Core.Exceptions;
using DataFIFA.Core.Helpers;
using DataFIFA.Core.Helpers.Interfaces;
using DataFIFA.Infrastructure.Persistence.Repositories.Interfaces;
using MediatR;

namespace DataFIFA.Application.Features.Users.Queries.GetById;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDetailsViewModel?>
{
    private readonly IUserRepository _userRepository;
    private readonly IMessageHandler _messageHandler;

    public GetUserByIdQueryHandler(IUserRepository userRepository, IMessageHandler messageHandler)
    {
        _userRepository = userRepository;
        _messageHandler = messageHandler;
    }
    
    public async Task<UserDetailsViewModel?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId, x => x.Careers);

        if (user is null)
        {
            var ex = new EntityNotFoundException("User", request.UserId);
            _messageHandler.AddMessage(new ErrorMessage(HttpStatusCode.NotFound, ex.Message));
            return null;
        }
        
        return user is null 
            ? null 
            : new UserDetailsViewModel(
                user.Id, 
                user.Email, 
                user.Name, 
                user.Careers.Select(x => 
                    new CareerViewModel(
                        x.Id, 
                        x.UserId, 
                        x.ManagerName, 
                        x.LastUpdate, 
                        x.Teams.MinBy(t => t.LastUpdate)?.Name)).ToList());
    }
}