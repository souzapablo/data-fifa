using DataFIFA.Application.Features.Players.Commands.AddPlayer;
using DataFIFA.Application.Validators.Shared;
using FluentValidation;

namespace DataFIFA.Application.Validators.Players
{
    public class AddPlayerCommandValidator : BaseValidator<AddPlayerCommand>
    {
        public AddPlayerCommandValidator()
        {
            RuleFor(x => x.FirstName)
                .NotNull()
                .WithMessage("Primeiro nome do jogador deve ser informado.");

            RuleFor(x => x.LastName)
                .NotNull()
                .WithMessage("Sobrenome do jogador deve ser informado.");

            RuleFor(x => x.Overall)
                .NotNull()
                .WithMessage("Geral do jogador deve ser informado.")
                .InclusiveBetween(1, 99)
                .WithMessage("Geral deve estar entre 1 e 99.");

            RuleFor(x => x.Age)
                .NotNull()
                .WithMessage("Idade do jogador deve ser informada.")
                .InclusiveBetween(15, 45)
                .WithMessage("Idade deve ser entre 15 e 45.");

            RuleFor(x => x.KitNumber)
                .NotNull()
                .WithMessage("Número da camisa do jogador deve ser informado.")
                .InclusiveBetween(1, 99)
                .WithMessage("Número da camisa do jogador deve estar entre 1 e 99."); ;

            RuleFor(x => x.Position)
                .NotNull()
                .WithMessage("Posição do jogador deve ser informada.")
                .IsInEnum()
                .WithMessage("Posição invalida");

                
        }
    }
}
