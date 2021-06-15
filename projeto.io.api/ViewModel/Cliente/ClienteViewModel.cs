using projeto.io.domain.ValueObjects;
using System;

namespace projeto.io.api.ViewModel.Cliente
{
    public class ClienteViewModel
    {
        public string Nome { get; set; }
        public CPF Cpf { get; set; }
        public string NomeMae { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool Ativo { get; set; }
    }
}
