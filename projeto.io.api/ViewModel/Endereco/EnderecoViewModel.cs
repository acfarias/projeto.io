using projeto.io.domain.Enums;

namespace projeto.io.api.ViewModel.Endereco
{
    public class EnderecoViewModel
    {
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public EnumTipoEndereco TipoEndereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Pais { get; set; }
    }
}
