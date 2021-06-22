using projeto.io.domain.core.Commands;
using projeto.io.domain.Enums;

namespace projeto.io.domain.ValueObjects
{
    public abstract class EnderecoBase : Command<bool>
    {
        protected EnderecoBase(string logradouro, string complemento, EnumTipoEndereco tipoEndereco, string bairro, string cidade, string pais)
        {
            Logradouro = logradouro;
            Complemento = complemento;
            TipoEndereco = tipoEndereco;
            Bairro = bairro;
            Cidade = cidade;
            Pais = pais;
        }

        public string Logradouro { get; protected set; }
        public string Complemento { get; protected set; }
        public EnumTipoEndereco TipoEndereco { get; protected set; }
        public string Bairro { get; protected set; }
        public string Cidade { get; protected set; }
        public string Pais { get; protected set; }
    }
}
