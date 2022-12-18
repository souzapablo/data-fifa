using System.Net;
using DataFIFA.Core.Entities;
using DataFIFA.Core.Exceptions;
using DataFIFA.Core.Helpers;
using DataFIFA.Core.Helpers.Interfaces;
using DataFIFA.Infrastructure.Persistence.Repositories.Interfaces;
using MediatR;

namespace DataFIFA.Application.Features.Users.Command.AddNewUser;

public class AddNewUserCommandHandler : IRequestHandler<AddNewUserCommand, Guid?>
{
    private readonly IUserRepository _userRepository;
    private readonly IMessageHandler _messageHandler;
    public AddNewUserCommandHandler(IUserRepository userRepository, IMessageHandler messageHandler)
    {
        _userRepository = userRepository;
        _messageHandler = messageHandler;
    }
    
    public async Task<Guid?> Handle(AddNewUserCommand request, CancellationToken cancellationToken)
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

        return user.Id;
    }
}