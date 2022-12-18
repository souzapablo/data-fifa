using DataFIFA.Application.ViewModels.Careers;
using MediatR;

namespace DataFIFA.Application.Features.Careers.Queries.GetById;

public class GetCareerByIdQuery : IRequest<CareerDetailsViewModel?>
{
    public GetCareerByIdQuery(Guid careerId)
    {
        CareerId = careerId;
    }
    public Guid CareerId { get; private set; }
}