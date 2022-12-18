using DataFIFA.Application.ViewModels.Careers;
using DataFIFA.Core.Entities;
using DataFIFA.Infrastructure.Persistence.Repositories.Interfaces;
using MediatR;

namespace DataFIFA.Application.Features.Careers.Queries.GetById;

public class GetCareerByIdQueryHandler : IRequestHandler<GetCareerByIdQuery, CareerDetailsViewModel?>
{
    private readonly ICareerRepository _careerRepository;

    public GetCareerByIdQueryHandler(ICareerRepository careerRepository)
    {
        _careerRepository = careerRepository;
    }
    
    public async Task<CareerDetailsViewModel?> Handle(GetCareerByIdQuery request, CancellationToken cancellationToken)
    {
        var career = await _careerRepository.GetByIdAsync(request.CareerCareerId, x => x.Teams);

        return career is null ?
            null :
            new CareerDetailsViewModel(
                career.Id, 
                career.UserId, 
                career.ManagerName, 
                career.Teams.MinBy(t => t.LastUpdate)?.Name, 
                career.Teams);
    }
}