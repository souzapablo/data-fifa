using DataFIFA.Application.ViewModels.Auth;
using MediatR;

namespace DataFIFA.Application.Features.Auth.Login;

public class LoginCommand : IRequest<LoginViewModel?>
{
    public LoginCommand(string name, string password)
    {
        Name = name;
        Password = password;
    }
    public string Name { get; set; }
    public string Password { get; set; }
}