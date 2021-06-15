using FluentValidation;
using projeto.io.domain.core.Commands;
using projeto.io.domain.ValueObjects;
using System;

namespace projeto.io.domain.Clientes.Commands
{
    public class AtualizarClienteCommand : Command<bool>
    {
        public AtualizarClienteCommand(Guid id, string nome, CPF cpf, string nomeMae, DateTime dataNascimento, bool ativo)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            NomeMae = nomeMae;
            DataNascimento = dataNascimento;
            Ativo = ativo;
        }

        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public CPF Cpf { get; private set; }
        public string NomeMae { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public bool Ativo { get; private set; }

        public override bool IsValid()
        {
            ValidationResult = new AtualizarClienteCommandValidacoes().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class AtualizarClienteCommandValidacoes : AbstractValidator<AtualizarClienteCommand>
    {
        public AtualizarClienteCommandValidacoes()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .NotEqual(Guid.Empty)
                .WithMessage("Informe o Id do Cliente");

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
