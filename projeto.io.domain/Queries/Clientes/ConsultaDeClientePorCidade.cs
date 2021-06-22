using projeto.io.domain.Commands.Clientes.Entities;
using projeto.io.domain.Commands.Clientes.Repositorio;
using projeto.io.domain.core.Notifications;
using projeto.io.domain.Interfaces;
using projeto.io.domain.Queries.Clientes.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace projeto.io.domain.Queries.Clientes
{
    public class ConsultaDeClientePorCidade : CommandHandler, IConsultaDeClientePorCidade
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly IMediatorHandler _mediatorHandler;

        public ConsultaDeClientePorCidade(IClienteRepositorio clienteRepositorio, IMediatorHandler mediatorHandler) : base(mediatorHandler)
        {
            _clienteRepositorio = clienteRepositorio;
            _mediatorHandler = mediatorHandler;
        }

        public async Task<IEnumerable<Cliente>> ConsultarClientePorCidade(string cidade)
        {
            if (string.IsNullOrWhiteSpace(cidade))
            {
                await _mediatorHandler.PublicarEvento(new DomainNotification("", "Informe uma cidade."));
                return null;
            }

            return await _clienteRepositorio.ConsultarClientePorCidade(cidade);
        }
    }
}
