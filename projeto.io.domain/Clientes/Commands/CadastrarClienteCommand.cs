using FluentValidation;
using projeto.io.domain.core.Commands;
using projeto.io.domain.ValueObjects;
using System;

namespace projeto.io.domain.Clientes.Commands
{
    public class CadastrarClienteCommand : Command<bool>
    {
        public CadastrarClienteCommand(string nome, CPF cpf, string nomeMae, DateTime dataNascimento, bool ativo)
        {
            Nome = nome;
            Cpf = cpf;
            NomeMae = nomeMae;
            DataNascimento = dataNascimento;
            Ativo = ativo;
        }

        public string Nome { get; private set; }
        public CPF Cpf { get; private set; }
        public string NomeMae { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public bool Ativo { get; private set; }

        public override bool IsValid()
        {
            ValidationResult = new CadastrarClienteCommandValidacoes().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class CadastrarClienteCommandValidacoes : AbstractValidator<CadastrarClienteCommand>
    {
        public CadastrarClienteCommandValidacoes()
        {
            RuleFor(c => c.Nome)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(150)
                .WithMessage("O nome é obrigatório e deve possuir entre 5 e 150 caracteres");

            RuleFor(c => c.NomeMae)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(150)
                .WithMessage("O nome da mãe é obrigatório e deve possuir entre 5 e 150 caracteres");
        }
    }
}
