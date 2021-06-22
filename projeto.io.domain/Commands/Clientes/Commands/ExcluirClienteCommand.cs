using FluentValidation;
using projeto.io.domain.core.Commands;
using System;

namespace projeto.io.domain.Commands.Clientes.Commands
{
    public class ExcluirClienteCommand : Command<bool>
    {
        public ExcluirClienteCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }

        public override bool IsValid()
        {
            ValidationResult = new ExcluirClienteCommandValidacoes().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class ExcluirClienteCommandValidacoes : AbstractValidator<ExcluirClienteCommand>
    {
        public ExcluirClienteCommandValidacoes()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .NotEqual(Guid.Empty)
                .WithMessage("Informe o Id do Cliente para excluir.");
        }
    }
}
