using AcfLib.ValidacaoCpfCnpj;
using FluentValidation;
using projeto.io.domain.core.Commands;

namespace projeto.io.domain.ValueObjects
{
    public class Documento : Command<bool>
    {
        public Documento(string cpf)
        {
            CPF = cpf;
            IsValid();
        }

        public string CPF { get; private set; }

        public override bool IsValid()
        {
            ValidationResult = new CPFValidacoes().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class CPFValidacoes : AbstractValidator<Documento>
    {
        public CPFValidacoes()
        {
            RuleFor(c => c.CPF)
                .Must(ValidacaoDeCpfCnpj.ValidarCpfCnpj)
                .WithMessage("Cpf inválido");
        }
    }
}
