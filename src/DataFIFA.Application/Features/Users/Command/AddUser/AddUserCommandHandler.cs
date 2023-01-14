using System.Net;
using DataFIFA.Application.ViewModels.Users;
using DataFIFA.Core.Constants;
using DataFIFA.Core.Entities;
using DataFIFA.Core.Helpers;
using DataFIFA.Core.Helpers.Interfaces;
using DataFIFA.Core.Services;
using DataFIFA.Infrastructure.Persistence.Repositories.Interfaces;
using MediatR;

namespace DataFIFA.Application.Features.Users.Command.AddUser;

public class AddUserCommandHandler : IRequestHandler<AddUserCommand, AddUserViewModel?>
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthService _authService;
    private readonly IMessageHandler _messageHandler;
    public AddUserCommandHandler(IUserRepository userRepository, IMessageHandler messageHandler,
        IAuthService authService)
    {
        _userRepository = userRepository;
        _messageHandler = messageHandler;
        _authService = authService;
    }
    
    public async Task<AddUserViewModel?> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        var isEmailRegistered = await _userRepository.IsEmailRegistered(request.Email);

        var passwordHash = _authService.ComputeSha256Hash(request.Password);
        
        if (isEmailRegistered)
        {
            _messageHandler.AddMessage(new ErrorMessage(HttpStatusCode.BadRequest, ErrorConstants.EmailAlreadyRegistered));
            return null;
        }
        
        var user = new User(request.Name, request.Email, passwordHash);

        await _userRepository.AddAsync(user);

        return new AddUserViewModel(user.Id, 
            user.Name, 
            user.Email);
    }
}