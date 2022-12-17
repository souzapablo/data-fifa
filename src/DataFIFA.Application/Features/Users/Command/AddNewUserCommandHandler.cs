using DataFIFA.Core.Entities;
using DataFIFA.Core.Exceptions;
using DataFIFA.Infrastructure.Persistence.Repositories.Interfaces;
using MediatR;

namespace DataFIFA.Application.Features.Users.Command;

public class AddNewUserCommandHandler : IRequestHandler<AddNewUserCommand, Guid>
{
    private readonly IUserRepository _userRepository;

    public AddNewUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<Guid> Handle(AddNewUserCommand request, CancellationToken cancellationToken)
    {
        var isEmailRegistered = await _userRepository.IsEmailRegistered(request.Email);

        if (isEmailRegistered)
            throw new EmailAlreadyRegisteredException();
        
        var user = new User(request.Name, request.Email, request.Password);

        await _userRepository.AddNewUser(user);

        return user.Id;
    }
}