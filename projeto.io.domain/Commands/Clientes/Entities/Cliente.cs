using projeto.io.domain.core.Modelos;
using System;

namespace projeto.io.domain.Commands.Clientes.Entities
{
    public partial class Cliente : Entity<Cliente>
    {
        public Cliente() { }

        public Cliente(Guid id, string nome, string cpf, string nomeMae, DateTime dataNascimento, bool ativo, Guid idEndereco)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            NomeMae = nomeMae;
            DataNascimento = dataNascimento;
            Ativo = ativo;
            IdEndereco = idEndereco;
        }

        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public string NomeMae { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public bool Ativo { get; private set; }
        public Guid IdEndereco { get; private set; }

        public EnderecoCliente Endereco { get; private set; }
    }
}
