using projeto.io.domain.core.Modelos;
using projeto.io.domain.Enums;
using System;
using System.Collections.Generic;

namespace projeto.io.domain.Commands.Clientes.Entities
{
    public partial class EnderecoCliente : Entity<EnderecoCliente>
    {
        public EnderecoCliente(Guid id, string logradouro, string complemento, EnumTipoEndereco tipoEndereco, string bairro, string cidade, string pais)
        {
            Id = id;
            Logradouro = logradouro;
            Complemento = complemento;
            TipoEndereco = tipoEndereco;
            Bairro = bairro;
            Cidade = cidade;
            Pais = pais;
        }

        public EnderecoCliente() { }

        public string Logradouro { get; private set; }
        public string Complemento { get; private set; }
        public EnumTipoEndereco TipoEndereco { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Pais { get; private set; }

        public ICollection<Cliente> Clientes { get; set; }
    }
}
