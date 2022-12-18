using DataFIFA.API.Controllers.Shared;
using DataFIFA.Application.Features.Careers.Commands.AddCareer;
using DataFIFA.Application.Features.Careers.Queries.GetById;
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
    public async Task<IActionResult> ListAllAsync()
    {
        var query = new ListAllCareersQuery();
        var result = await _mediator.Send(query);
        
        return CustomResponse(result);
    }

    [HttpGet("{careerId:guid}")]
    public async Task<IActionResult> GetCareerByIdAsnyc(Guid careerId)
    {
        var query = new GetCareerByIdQuery(careerId);
        var result = await _mediator.Send(query);

        return CustomResponse(result);
    }

    [HttpPost]
    public async Task<IActionResult> AddCareerAsync([FromBody] AddCareerInputModel input)
    {
        var command = new AddCareerCommand(input.UserId, input.ManagerName);
        var result = await _mediator.Send(command);

        return CustomResponse(result);
    }
}