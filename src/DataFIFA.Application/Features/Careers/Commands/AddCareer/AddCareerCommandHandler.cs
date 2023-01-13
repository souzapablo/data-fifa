using DataFIFA.Application.ViewModels.Careers;
using DataFIFA.Core.Constants;
using DataFIFA.Core.Entities;
using DataFIFA.Core.Helpers;
using DataFIFA.Core.Helpers.Interfaces;
using DataFIFA.Infrastructure.Persistence.Repositories.Interfaces;
using MediatR;
using System.Net;

namespace DataFIFA.Application.Features.Careers.Commands.AddCareer;

public class AddCareerCommandHandler : IRequestHandler<AddCareerCommand, AddCareerViewModel?>
{
    private readonly ICareerRepository _careerRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMessageHandler _messageHandler;

    public AddCareerCommandHandler(ICareerRepository careerRepository, IUserRepository userRepository,
        IMessageHandler messageHandler)
    {
        _careerRepository = careerRepository;
        _userRepository = userRepository;
        _messageHandler = messageHandler;
    }
    
    public async Task<AddCareerViewModel?> Handle(AddCareerCommand request, CancellationToken cancellationToken)
    {
        var career = new Career(request.UserId, request.ManagerName);

        var user = await _userRepository.GetByIdAsync(request.UserId);

        if (user is null)
        {
            _messageHandler.AddMessage(new ErrorMessage(HttpStatusCode.BadRequest, ErrorConstants.UserNotFound(request.UserId)));
            return null;
        }

        await _careerRepository.AddAsync(career);

        return new AddCareerViewModel(
            career.Id, 
            career.UserId, 
            career.ManagerName);
    }
}