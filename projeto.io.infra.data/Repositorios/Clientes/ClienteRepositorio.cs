using Microsoft.EntityFrameworkCore;
using projeto.io.domain.Clientes;
using projeto.io.domain.Clientes.Repositorio;
using projeto.io.domain.ValueObjects;
using projeto.io.infra.data.Contexto;
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

        public async Task<Cliente> ObterPorCpf(CPF Cpf)
        {
            return await _contextoProjeto.Clientes.FirstOrDefaultAsync(c => c.Cpf.Cpf == Cpf.Cpf);
        }
    }
}
