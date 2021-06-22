using projeto.io.domain.Commands.Clientes.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace projeto.io.domain.Queries.Clientes.Interfaces
{
    public interface IConsultaDeClientePorCidade
    {
        Task<IEnumerable<Cliente>> ConsultarClientePorCidade(string cidade);
    }
}
