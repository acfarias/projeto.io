using FluentValidation;
using projeto.io.domain.core.Commands;
using projeto.io.domain.ValueObjects;
using System;

namespace projeto.io.domain.Commands.Clientes.Commands
{
    public class CadastrarClienteCommand : Command<bool>
    {
        public CadastrarClienteCommand(string nome, Documento cpf, string nomeMae, DateTime dataNascimento, bool ativo, Endereco endereco)
        {
            Nome = nome;
            Cpf = cpf;
            NomeMae = nomeMae;
            DataNascimento = dataNascimento;
            Ativo = ativo;
            Endereco = endereco;
        }

        public string Nome { get; private set; }
        public Documento Cpf { get; private set; }
        public string NomeMae { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public bool Ativo { get; private set; }

        public Endereco Endereco { get; private set; }

        public override bool IsValid()
        {
            ValidationResult = new CadastrarClienteCommandValidacoes().Validate(this);
            if (!Cpf.ValidationResult.IsValid)
                ValidationResult.Errors.AddRange(Cpf.ValidationResult.Errors);
            if (!Endereco.ValidationResult.IsValid)
                ValidationResult.Errors.AddRange(Endereco.ValidationResult.Errors);

            return ValidationResult.IsValid;
        }
    }

    public class CadastrarClienteCommandValidacoes : AbstractValidator<CadastrarClienteCommand>
    {
        public CadastrarClienteCommandValidacoes()
        {
            RuleFor(c => c.Nome)
                .Must(c => c.Length > 5 && c.Length < 150)
                .WithMessage("O nome é obrigatório e deve possuir entre 5 e 150 caracteres");

            RuleFor(c => c.NomeMae)
                .Must(c => c.Length > 5 && c.Length < 150)
                .WithMessage("O nome da mãe é obrigatório e deve possuir entre 5 e 150 caracteres");
        }
    }
}
