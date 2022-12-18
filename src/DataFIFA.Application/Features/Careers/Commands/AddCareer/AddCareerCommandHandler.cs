using DataFIFA.Application.ViewModels.Careers;
using DataFIFA.Core.Entities;
using DataFIFA.Core.Helpers.Interfaces;
using DataFIFA.Infrastructure.Persistence.Repositories.Interfaces;
using MediatR;

namespace DataFIFA.Application.Features.Careers.Commands.AddCareer;

public class AddCareerCommandHandler : IRequestHandler<AddCareerCommand, CareerDetailsViewModel>
{
    private readonly ICareerRepository _careerRepository;
    private readonly IMessageHandler _messageHandler;

    public AddCareerCommandHandler(ICareerRepository careerRepository, IMessageHandler messageHandler)
    {
        _messageHandler = messageHandler;
        _careerRepository = careerRepository;
    }
    
    public async Task<CareerDetailsViewModel> Handle(AddCareerCommand request, CancellationToken cancellationToken)
    {
        var career = new Career(request.UserId, request.ManagerName);

        await _careerRepository.AddAsync(career);

        return new CareerDetailsViewModel(career.Id, career.UserId, career.ManagerName, new List<Team>());
    }
}