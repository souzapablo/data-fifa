using System.Net;
using DataFIFA.Application.ViewModels.Teams;
using DataFIFA.Core.Entities;
using DataFIFA.Core.Exceptions;
using DataFIFA.Core.Helpers;
using DataFIFA.Core.Helpers.Interfaces;
using DataFIFA.Infrastructure.Persistence.Repositories.Interfaces;
using MediatR;

namespace DataFIFA.Application.Features.Teams.Commands.AddTeam;

public class AddTeamCommandHandler : IRequestHandler<AddTeamCommand, AddTeamViewModel?>
{
    private readonly ITeamRepository _teamRepository;
    private readonly ICareerRepository _careerRepository;
    private readonly IMessageHandler _messageHandler;

    public AddTeamCommandHandler(ITeamRepository teamRepository, ICareerRepository careerRepository,
        IMessageHandler messageHandler)
    {
        _teamRepository = teamRepository;
        _careerRepository = careerRepository;
        _messageHandler = messageHandler;
    }
    
    public async Task<AddTeamViewModel?> Handle(AddTeamCommand request, CancellationToken cancellationToken)
    {
        var team = new Team(request.CareerId, request.Name, request.Stadium);
        
        var career = await _careerRepository.GetByIdAsync(request.CareerId);

        if (career is null)
        {
            var ex = new EntityNotFoundException("Career", request.CareerId);
            _messageHandler.AddMessage(new ErrorMessage(HttpStatusCode.NotFound, ex.Message));
            return null;
        }
        
        await _teamRepository.AddAsync(team);
        
        career.AddTeam(team.Id);

        await _careerRepository.UpdateAsync(career);
        
        return new AddTeamViewModel(
            team.Id,
            team.CareerId,
            team.Name,
            team.Stadium);
    }
}