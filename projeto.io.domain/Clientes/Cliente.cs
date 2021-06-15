using projeto.io.domain.core.Modelos;
using projeto.io.domain.ValueObjects;
using System;

namespace projeto.io.domain.Clientes
{
    public class Cliente : Entity<Cliente>
    {
        public Cliente(Guid id, string nome, CPF cpf, string nomeMae, DateTime dataNascimento, bool ativo)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            NomeMae = nomeMae;
            DataNascimento = dataNascimento;
            Ativo = ativo;
        }
        public Cliente() { }

        public string Nome { get; private set; }
        public CPF Cpf { get; private set; }
        public string NomeMae { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public bool Ativo { get; private set; }
    }
}
