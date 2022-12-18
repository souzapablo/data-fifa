using DataFIFA.API.Controllers.Shared;
using DataFIFA.Application.Features.Users.Command;
using DataFIFA.Application.Features.Users.Command.AddNewUser;
using DataFIFA.Application.Features.Users.Queries.GetUserById;
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
    public async Task<IActionResult> ListUsers()
    {
        var query = new ListUsersQuery();
        return CustomResponse(await _mediator.Send(query));
    }

    [HttpGet("{userId:guid}")]
    public async Task<IActionResult> GetUserById(Guid userId)
    {
        var query = new GetUserByIdQuery(userId);
        var user = await _mediator.Send(query);
        
        return CustomResponse(user);
    }

    [HttpPost]
    public async Task<IActionResult> AddNewUser(AddNewUserInputModel input)
    {
        var command = new AddNewUserCommand(input.Name, input.Email, input.Password);
        var id = await _mediator.Send(command);

        return CustomResponse(id);
    }
 
}