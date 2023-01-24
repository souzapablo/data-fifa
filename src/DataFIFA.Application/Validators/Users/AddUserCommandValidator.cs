using DataFIFA.Application.Features.Users.Command.AddUser;
using DataFIFA.Application.Validators.Shared;
using FluentValidation;
using System.Text.RegularExpressions;

namespace DataFIFA.Application.Validators.Users
{
    public class AddUserCommandValidator : BaseValidator<AddUserCommand>
    {
        public AddUserCommandValidator()
        {
            RuleFor(x => x.Email)
                .EmailAddress()
                .WithMessage("E-mail inválido.");

            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("O nome é obrigatório.");

            RuleFor(x => x.Password)
                .Must(ValidPassword)
                .WithMessage("Senha deve conter pelo menos 8 caracateres, um número, uma letra maiúscula, uma minúscula e um caractere especial.");
        }

        public static bool ValidPassword(string password)
        {
            var regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$");

            return regex.IsMatch(password);
        }
    }
}
