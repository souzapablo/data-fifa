using DataFIFA.Application.ViewModels.Careers;
using DataFIFA.Core.Constants;
using DataFIFA.Core.Entities;
using DataFIFA.Core.Helpers;
using DataFIFA.Core.Helpers.Interfaces;
using DataFIFA.Infrastructure.Persistence.Repositories.Interfaces;
using MediatR;
using System.Net;
using DataFIFA.Core.Helpers.Files.InitialTeams;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using DataFIFA.Application.Validators.Careers;

namespace DataFIFA.Application.Features.Careers.Commands.AddCareer;

public class AddCareerCommandHandler : IRequestHandler<AddCareerCommand, AddCareerViewModel?>
{
    private readonly ICareerRepository _careerRepository;
    private readonly IUserRepository _userRepository;
    private readonly ITeamRepository _teamRepository;
    private readonly IPlayerRepository _playerRepository;
    private readonly IConfiguration _configuration;
    private readonly IMessageHandler _messageHandler;

    public AddCareerCommandHandler(ICareerRepository careerRepository, IUserRepository userRepository,
        ITeamRepository teamRepository, IPlayerRepository playerRepository, IConfiguration configuration, 
        IMessageHandler messageHandler)
    {
        _careerRepository = careerRepository;
        _userRepository = userRepository;
        _teamRepository = teamRepository;
        _playerRepository = playerRepository;
        _configuration = configuration;
        _messageHandler = messageHandler;
    }
    
    public async Task<AddCareerViewModel?> Handle(AddCareerCommand request, CancellationToken cancellationToken)
    {
        var validationErrors = new AddCareerCommandValidator().ListErrors(request);

        if (validationErrors.Any())
        {
            _messageHandler.AddRangeMessages(validationErrors);
            return null;
        }

        var career = new Career(request.UserId, request.ManagerName);

        var user = await _userRepository.GetByIdAsync(request.UserId);

        if (user is null)
        {
            _messageHandler.AddMessage(new ErrorMessage(HttpStatusCode.BadRequest, ErrorConstants.UserNotFound(request.UserId)));
            return null;
        }

        await using var connection = new SqlConnection(_configuration.GetConnectionString("DataFIFADb"));

        await connection.OpenAsync(cancellationToken);

        var transaction = connection.BeginTransaction();

        try
        {
            await _careerRepository.AddAsync(career);
            
            var teamId = await AddInitialTeam(career.Id, request.InitialTeamName);

            career.SetCurrentTeam(teamId);

            await _careerRepository.UpdateAsync(career);
            
            transaction.Commit();
            
            return new AddCareerViewModel(
                career.Id,
                career.UserId,
                teamId,
                career.ManagerName);
        }
        catch
        {
            transaction.Rollback();
            _messageHandler.AddMessage(new ErrorMessage(HttpStatusCode.BadRequest,
                ErrorConstants.InitialTeamNotFound(request.InitialTeamName)));
            return null;
        }
        
    }

    private async Task<Guid> AddInitialTeam(Guid careerId, string initialTeamName)
    {
        using StreamReader r = new($"./../DataFIFA.Core/Helpers/Files/InitialTeams/{initialTeamName}.json");

        var json = await r.ReadToEndAsync();

        var initialTeam = JsonConvert.DeserializeObject<InitialTeam>(json);

        var team = new Team(careerId, initialTeam.Name, initialTeam.Stadium);

        await _teamRepository.AddAsync(team);

        var lineUp = initialTeam.LineUp.Select(player => 
            new Player(
                team.Id, 
                player.FirstName, 
                player.LastName, 
                player.Overall, 
                player.KitNumber, 
                player.Situation, 
                player.Position, 
                player.Age)).ToList();

        await _playerRepository.AddLineUpAsync(lineUp);

        return team.Id;
    }
}