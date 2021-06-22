using Microsoft.EntityFrameworkCore;
using projeto.io.domain.Commands.Clientes.Entities;
using projeto.io.domain.Commands.Clientes.Repositorio;
using projeto.io.infra.data.Contexto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto.io.infra.data.Repositorios.Clientes
{
    public class ClienteRepositorio : Repositorio<Cliente>, IClienteRepositorio
    {
        private readonly ContextoProjeto _contextoProjeto;
        public ClienteRepositorio(ContextoProjeto contextoProjeto) : base(contextoProjeto)
        {
            _contextoProjeto = contextoProjeto;
        }

        public async Task<IEnumerable<Cliente>> ConsultarClientePorCidade(string cidade)
        {
            return await _contextoProjeto.Clientes
                .Include(c => c.Endereco)
                .Where(c => c.Endereco.Cidade == cidade)
                .ToListAsync();
        }

        public async Task<IEnumerable<Cliente>> ObterClientes()
        {
            return await _contextoProjeto.Clientes
                .Include(c => c.Endereco)
                .AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<EnderecoCliente>> ObterEnderecosClientes()
        {
            return await _contextoProjeto.EnderecoClientes.AsNoTracking().ToListAsync();
        }

        public async Task<Cliente> ObterPorCpf(string Cpf)
        {
            return await _contextoProjeto.Clientes.FirstOrDefaultAsync(c => c.Cpf == Cpf);
        }
    }
}
