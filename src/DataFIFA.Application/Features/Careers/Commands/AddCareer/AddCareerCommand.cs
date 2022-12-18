using DataFIFA.Application.ViewModels.Careers;
using MediatR;

namespace DataFIFA.Application.Features.Careers.Commands.AddCareer;

public class AddCareerCommand : IRequest<CareerDetailsViewModel>
{
    public AddCareerCommand(Guid userId, string managerName)
    {
        UserId = userId;
        ManagerName = managerName;
    }
    
    public Guid UserId { get; set; }
    public string ManagerName { get; set; }
}