using System.Net;
using DataFIFA.Application.ViewModels.Careers;
using DataFIFA.Core.Exceptions;
using DataFIFA.Core.Helpers;
using DataFIFA.Core.Helpers.Interfaces;
using DataFIFA.Infrastructure.Persistence.Repositories.Interfaces;
using MediatR;

namespace DataFIFA.Application.Features.Careers.Queries.GetById;

public class GetCareerByIdQueryHandler : IRequestHandler<GetCareerByIdQuery, CareerDetailsViewModel?>
{
    private readonly ICareerRepository _careerRepository;
    private readonly IMessageHandler _messageHandler;

    public GetCareerByIdQueryHandler(ICareerRepository careerRepository, IMessageHandler messageHandler)
    {
        _careerRepository = careerRepository;
        _messageHandler = messageHandler;
    }
    
    public async Task<CareerDetailsViewModel?> Handle(GetCareerByIdQuery request, CancellationToken cancellationToken)
    {
        var career = await _careerRepository.GetByIdAsync(request.CareerId, x => x.Teams, x => x.CurrentTeam);

        if (career is null)
        {
            var ex = new EntityNotFoundException("Career", request.CareerId);
            _messageHandler.AddMessage(new ErrorMessage(HttpStatusCode.NotFound, ex.Message));
            return null;
        }

        return new CareerDetailsViewModel(
                career.Id, 
                career.UserId, 
                career.ManagerName, 
                career.CurrentTeam?.Name);
    }
}