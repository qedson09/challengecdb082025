using FluentValidation;

namespace cdbservice.Core.UseCases
{
    public class CalcularCdbPosFixadoCommandValidator : AbstractValidator<CalcularCdbPosFixadoCommand>
    {
        public CalcularCdbPosFixadoCommandValidator()
        {
            RuleFor(x => x.ValorInicial)
                .GreaterThan(0).WithMessage("Valor inicial deve ser maior que zero.");

            RuleFor(x => x.Meses)
                .GreaterThan(1).WithMessage("Número de meses deve ser maior que 1.");
        }
    }
}
