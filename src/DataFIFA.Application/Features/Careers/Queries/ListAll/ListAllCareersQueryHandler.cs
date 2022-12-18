using DataFIFA.Application.ViewModels.Careers;
using DataFIFA.Core.Entities;
using DataFIFA.Core.Helpers.Interfaces;
using DataFIFA.Infrastructure.Persistence.Repositories.Interfaces;
using MediatR;

namespace DataFIFA.Application.Features.Careers.Queries.ListAll;

public class ListAllCareersQueryHandler : IRequestHandler<ListAllCareersQuery, List<CareerViewModel>>
{
    private readonly ICareerRepository _careerRepository;
    private readonly IMessageHandler _messageHandler;

    public ListAllCareersQueryHandler(ICareerRepository careerRepository, IMessageHandler messageHandler)
    {
        _careerRepository = careerRepository;
        _messageHandler = messageHandler;
    }
    
    public async Task<List<CareerViewModel>> Handle(ListAllCareersQuery request, CancellationToken cancellationToken)
    {
        var careers = await _careerRepository.ListAllAsync();

        return careers.Select(x => new CareerViewModel(x.Id, x.UserId, x.ManagerName, new List<Team>())).ToList();
    }
}