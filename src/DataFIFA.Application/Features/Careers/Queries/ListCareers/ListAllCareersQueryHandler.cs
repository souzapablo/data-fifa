using DataFIFA.Application.ViewModels.Careers;
using DataFIFA.Infrastructure.Persistence.Repositories.Interfaces;
using MediatR;

namespace DataFIFA.Application.Features.Careers.Queries.ListCareers;

public class ListAllCareersQueryHandler : IRequestHandler<ListAllCareersQuery, List<CareerViewModel>>
{
    private readonly ICareerRepository _careerRepository;
    public ListAllCareersQueryHandler(ICareerRepository careerRepository)
    {
        _careerRepository = careerRepository;
    }
    
    public async Task<List<CareerViewModel>> Handle(ListAllCareersQuery request, CancellationToken cancellationToken)
    {
        var careers = await _careerRepository.ListAllAsync(x => x.Teams);

        return careers.Select(x => new CareerViewModel(
            x.Id, 
            x.UserId, 
            x.ManagerName, 
            x.LastUpdate, 
            x.Teams.MinBy(t => t.LastUpdate)?.Name)).ToList();
    }
}