using AcfLib.ValidacaoCpfCnpj;
using FluentValidation;
using projeto.io.domain.core.Commands;

namespace projeto.io.domain.ValueObjects
{
    public class CPF : Command<bool>
    {
        public CPF(string cpf)
        {
            Cpf = cpf;
        }

        public string Cpf { get; private set; }

        public override bool IsValid()
        {
            ValidationResult = new CPFValidacoes().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class CPFValidacoes : AbstractValidator<CPF>
    {
        public CPFValidacoes()
        {
            RuleFor(c => c.Cpf)
                .Must(ValidacaoDeCpfCnpj.ValidarCpfCnpj)
                .WithMessage("Cpf inválido");
        }
    }
}
