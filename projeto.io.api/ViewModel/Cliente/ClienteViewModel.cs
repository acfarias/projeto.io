using projeto.io.api.ViewModel.Endereco;
using System;

namespace projeto.io.api.ViewModel.Cliente
{
    public class ClienteViewModel
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string NomeMae { get; set; }
        public DateTime DataNascimento { get; set; }
        public EnderecoViewModel Endereco { get; set; }
    }
}
