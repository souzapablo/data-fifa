using DataFIFA.Application.ViewModels.Careers;
using MediatR;

namespace DataFIFA.Application.Features.Careers.Commands.AddCareer;

public class AddCareerCommand : IRequest<AddCareerViewModel>
{
    public AddCareerCommand(Guid userId, string managerName, string initialTeamName)
    {
        UserId = userId;
        ManagerName = managerName;
        InitialTeamName = initialTeamName;
    }
    
    public Guid UserId { get; set; }
    public string ManagerName { get; set; }
    public string InitialTeamName { get; set; }
}