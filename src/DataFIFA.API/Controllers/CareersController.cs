using DataFIFA.API.Controllers.Shared;
using DataFIFA.Application.Features.Careers.Queries.ListAll;
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
    public async Task<IActionResult> ListAll()
    {
        var query = new ListAllCareersQuery();
        var result = await _mediator.Send(query);
        
        return CustomResponse(result);
    }
}