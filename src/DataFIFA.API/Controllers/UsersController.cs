using DataFIFA.API.Controllers.Shared;
using DataFIFA.Application.Features.Users.Command.AddUser;
using DataFIFA.Application.Features.Users.Queries.GetById;
using DataFIFA.Application.Features.Users.Queries.ListUsers;
using DataFIFA.Application.InputModels.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DataFIFA.API.Controllers;

[ApiController]
[Route("/api/v1/users")]
public class UsersController : BaseController
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<IActionResult> ListUsersAsync()
    {
        var query = new ListUsersQuery();
        return CustomResponse(await _mediator.Send(query));
    }

    [HttpGet("{userId:guid}")]
    public async Task<IActionResult> GetUserByIdAsync(Guid userId)
    {
        var query = new GetUserByIdQuery(userId);
        var user = await _mediator.Send(query);
        
        return CustomResponse(user);
    }

    [HttpPost]
    public async Task<IActionResult> AddUserAsync(AddNewUserInputModel input)
    {
        var command = new AddUserCommand(input.Name, input.Email, input.Password);
        var newUser = await _mediator.Send(command);

        return CustomResponse(newUser);
    }
 
}