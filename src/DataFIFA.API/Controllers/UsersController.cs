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

    [HttpGet("{userId:guid}")]
    public async Task<IActionResult> GetUserById(Guid userId)
    {
        var query = new GetUserByIdQuery(userId);
        var user = await _mediator.Send(query);
        
        if (user is null)
            return NotFound($"User with Id {userId} not found");

        return Ok(user);
    }
 
}