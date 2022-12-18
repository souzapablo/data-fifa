using DataFIFA.Application.ViewModels.Users;
using MediatR;

namespace DataFIFA.Application.Features.Users.Command.AddUser;

public class AddUserCommand : IRequest<UserDetailsViewModel?>
{
    public AddUserCommand(string name, string email, string password)
    {
        Name = name;
        Email = email;
        Password = password;
    }

    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}