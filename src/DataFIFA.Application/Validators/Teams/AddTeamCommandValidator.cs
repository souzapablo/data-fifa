using DataFIFA.Application.Features.Teams.Commands.AddTeam;
using DataFIFA.Application.Validators.Shared;
using FluentValidation;

namespace DataFIFA.Application.Validators.Teams
{
    public class AddTeamCommandValidator : BaseValidator<AddTeamCommand>
    {
        public AddTeamCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("Nome do time deve ser informado.");

            RuleFor(x => x.Stadium)
                .NotNull()
                .WithMessage("Nome do estádio deve ser informado.");
        }
    }
}
