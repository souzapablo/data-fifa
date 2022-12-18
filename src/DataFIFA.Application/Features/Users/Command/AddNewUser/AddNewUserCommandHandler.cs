using System.Net;
using DataFIFA.Application.ViewModels.Users;
using DataFIFA.Core.Entities;
using DataFIFA.Core.Exceptions;
using DataFIFA.Core.Helpers;
using DataFIFA.Core.Helpers.Interfaces;
using DataFIFA.Infrastructure.Persistence.Repositories.Interfaces;
using MediatR;

namespace DataFIFA.Application.Features.Users.Command.AddNewUser;

public class AddNewUserCommandHandler : IRequestHandler<AddNewUserCommand, UserDetailsViewModel?>
{
    private readonly IUserRepository _userRepository;
    private readonly IMessageHandler _messageHandler;
    public AddNewUserCommandHandler(IUserRepository userRepository, IMessageHandler messageHandler)
    {
        _userRepository = userRepository;
        _messageHandler = messageHandler;
    }
    
    public async Task<UserDetailsViewModel?> Handle(AddNewUserCommand request, CancellationToken cancellationToken)
    {
        var isEmailRegistered = await _userRepository.IsEmailRegistered(request.Email);

        if (isEmailRegistered)
        {
            var ex = new EmailAlreadyRegisteredException();
            _messageHandler.AddMessage(new ErrorMessage(HttpStatusCode.BadRequest, ex.Message));
            return null;
        }
        
        var user = new User(request.Name, request.Email, request.Password);

        await _userRepository.AddNewUser(user);

        return new UserDetailsViewModel(user.Id, user.Name, user.Email, new List<Career>());
    }
}