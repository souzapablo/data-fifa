using DataFIFA.Application.Features.Careers.Commands.AddCareer;
using DataFIFA.Application.Validators.Shared;
using DataFIFA.Core.Helpers.Files.InitialTeams;
using FluentValidation;

namespace DataFIFA.Application.Validators.Careers
{
    public class AddCareerCommandValidator : BaseValidator<AddCareerCommand>
    {
        public AddCareerCommandValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty()
                .NotNull()
                .WithMessage("Id do usuário deve ser informado.");

            RuleFor(x => x.ManagerName)
                .NotEmpty().NotNull().WithMessage("Nome do treinador deve ser informado.")
                .MinimumLength(3).WithMessage("Nome do treinador deve conter no mínimo 3 caracteres.")
                .MaximumLength(15).WithMessage("Nome do treinador deve conter no máximo 15 caracteres.");

            RuleFor(x => x.InitialTeamName)
                .Must(ValidInitialTeamName)
                .WithMessage("Time inicial indisponível.");

        }

        public static bool ValidInitialTeamName(string initialTeamName) => InitialTeamList.TeamList.Contains(initialTeamName);
        
    }
}
