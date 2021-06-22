using FluentValidation;
using projeto.io.domain.Enums;

namespace projeto.io.domain.ValueObjects
{
    public class Endereco : EnderecoBase
    {
        public Endereco(string logradouro, string complemento, EnumTipoEndereco tipoEndereco, string bairro, string cidade, string pais) 
                        : base(logradouro, complemento, tipoEndereco, bairro, cidade, pais)
        {
            IsValid();
        }

        public override bool IsValid()
        {
            ValidationResult = new EnderecoValidacoes().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class EnderecoValidacoes : AbstractValidator<Endereco>
    {
        public EnderecoValidacoes()
        {
            RuleFor(e => e.Logradouro)
            .NotEmpty()
            .WithMessage("Informe o logradouro");

            RuleFor(e => e.Bairro)
                .NotEmpty()
                .WithMessage("Informe o bairro");

            RuleFor(e => e.Cidade)
                .NotEmpty()
                .WithMessage("Informe a cidade");

            RuleFor(e => e.TipoEndereco)
                .NotEmpty()
                .WithMessage("Informe o Tipo de Endereço");
        }
    }
}
