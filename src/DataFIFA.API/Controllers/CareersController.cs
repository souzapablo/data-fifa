using DataFIFA.API.Controllers.Shared;
using DataFIFA.Application.Features.Careers.Commands.AddCareer;
using DataFIFA.Application.Features.Careers.Commands.DeleteCareer;
using DataFIFA.Application.Features.Careers.Queries.GetById;
using DataFIFA.Application.Features.Careers.Queries.GetByUserId;
using DataFIFA.Application.Features.Careers.Queries.ListCareers;
using DataFIFA.Application.InputModels.Careers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DataFIFA.API.Controllers;

[ApiController]
[Route("/api/v1/careers")]
public class CareersController : BaseController
{
    private readonly IMediator _mediator;

    public CareersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> ListCareersAsync()
    {
        var query = new ListAllCareersQuery();
        var result = await _mediator.Send(query);
        
        return CustomResponse(result);
    }

    [HttpGet("user/{userId:guid}")]
    public async Task<IActionResult> GetCareersByUserId(Guid userId)
    {
        var query = new GetCareerByUserIdQuery(userId);
        var result = await _mediator.Send(query);

        return CustomResponse(result);
    }

    [HttpGet("{careerId:guid}")]
    public async Task<IActionResult> GetCareerByIdAsync(Guid careerId)
    {
        var query = new GetCareerByIdQuery(careerId);
        var result = await _mediator.Send(query);

        return CustomResponse(result);
    }

    [HttpPost]
    public async Task<IActionResult> AddCareerAsync([FromBody] AddCareerInputModel input)
    {
        var command = new AddCareerCommand(input.UserId, input.ManagerName, input.InitialTeamName);
        var result = await _mediator.Send(command);

        return CustomResponse(result);
    }

    [HttpDelete("{careerId:guid}")]
    public async Task<IActionResult> DeleteCareerAsync(Guid careerId)
    {
        var command = new DeleteCareerCommand(careerId);
        var result = await _mediator.Send(command);

        return CustomResponse(result);
    }
}