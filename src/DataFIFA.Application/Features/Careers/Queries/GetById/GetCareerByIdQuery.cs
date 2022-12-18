using DataFIFA.Application.ViewModels.Careers;
using MediatR;

namespace DataFIFA.Application.Features.Careers.Queries.GetById;

public class GetCareerByIdQuery : IRequest<CareerDetailsViewModel?>
{
    public GetCareerByIdQuery(Guid careerId)
    {
        CareerCareerId = careerId;
    }
    public Guid CareerCareerId { get; private set; }
}