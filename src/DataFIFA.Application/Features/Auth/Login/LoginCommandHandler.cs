using System.Net;
using DataFIFA.Application.ViewModels.Auth;
using DataFIFA.Core.Constants;
using DataFIFA.Core.Helpers;
using DataFIFA.Core.Helpers.Interfaces;
using DataFIFA.Core.Services;
using DataFIFA.Infrastructure.Persistence.Repositories.Interfaces;
using MediatR;

namespace DataFIFA.Application.Features.Auth.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginViewModel?>
{
    private readonly IAuthService _authService;
    private readonly IUserRepository _userRepository;
    private readonly IMessageHandler _messageHandler;
    
    public LoginCommandHandler(IAuthService authService, IUserRepository userRepository,
        IMessageHandler messageHandler)
    {
        _authService = authService;
        _userRepository = userRepository;
        _messageHandler = messageHandler;
    }
    public async Task<LoginViewModel?> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var passwordHash = _authService.ComputeSha256Hash(request.Password);

        var user = await _userRepository.GetUserByNameAndPassword(request.Name, passwordHash);

        if (user is null)
        {
            _messageHandler.AddMessage(new ErrorMessage(HttpStatusCode.NotFound, ErrorConstants.InvalidUserNameOrPassword));
            return null;
        }

        var token = _authService.GenerateJwtToken(user.Name);
        
        return new LoginViewModel(user.Id, user.Name, token);
    }
}