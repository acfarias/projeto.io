using projeto.io.domain.Commands.Clientes.Entities;
using projeto.io.domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace projeto.io.domain.Commands.Clientes.Repositorio
{
    public interface IClienteRepositorio : IRepositorio<Cliente>
    {
        Task<Cliente> ObterPorCpf(string Cpf);
        Task<IEnumerable<EnderecoCliente>> ObterEnderecosClientes();
        Task<IEnumerable<Cliente>> ObterClientes();
        Task<IEnumerable<Cliente>> ConsultarClientePorCidade(string cidade);
    }
}
