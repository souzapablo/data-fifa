using DataFIFA.Application.ViewModels.Careers;
using DataFIFA.Infrastructure.Persistence.Repositories.Interfaces;
using MediatR;

namespace DataFIFA.Application.Features.Careers.Queries.GetByUserId;

public class GetCareerByUserIdQueryHandler : IRequestHandler<GetCareerByUserIdQuery, List<CareerDetailsViewModel>?>
{
    private readonly ICareerRepository _careerRepository;

    public GetCareerByUserIdQueryHandler(ICareerRepository careerRepository)
    {
        _careerRepository = careerRepository;
    }
    
    public async Task<List<CareerDetailsViewModel>?> Handle(GetCareerByUserIdQuery request, CancellationToken cancellationToken)
    {
        var careers = await _careerRepository.GetByUserId(request.UserId);

        return careers.Select(x => new CareerDetailsViewModel(
            x.Id,
            x.UserId,
            x.ManagerName,
            x.CurrentTeam?.Name)).ToList();
    }
}