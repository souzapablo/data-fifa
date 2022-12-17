using DataFIFA.Application.Features.Users.Queries.GetUserById;
using DataFIFA.Application.Features.Users.Queries.ListUsers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DataFIFA.API.Controllers;

[ApiController]
[Route("/api/v1/users")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<IActionResult> ListUsers()
    {
        var query = new ListUsersQuery();
        return Ok(await _mediator.Send(query));
    }
 
}