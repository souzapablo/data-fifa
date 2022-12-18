using MediatR;

namespace DataFIFA.Application.Features.Users.Command.AddNewUser;

public class AddNewUserCommand : IRequest<Guid?>
{
    public AddNewUserCommand(string name, string email, string password)
    {
        Name = name;
        Email = email;
        Password = password;
    }

    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}