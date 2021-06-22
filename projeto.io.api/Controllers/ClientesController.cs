using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using projeto.io.api.ViewModel.Cliente;
using projeto.io.domain.Commands.Clientes.Commands;
using projeto.io.domain.Commands.Clientes.Repositorio;
using projeto.io.domain.core.Notifications;
using projeto.io.domain.Interfaces;
using projeto.io.domain.Queries.Clientes.Interfaces;
using System.Threading.Tasks;

namespace projeto.io.api.Controllers
{
    [Route("projeto/v1/clientes")]
    public class ClientesController : BaseController
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IMapper _mapper;
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly IConsultaDeClientePorCidade _consultaDeClientePorCidade;

        public ClientesController(IMediatorHandler mediatorHandler,
                                  IMapper mapper,
                                  INotificationHandler<DomainNotification> notificationHandler,
                                  IClienteRepositorio clienteRepositorio,
                                  IConsultaDeClientePorCidade consultaDeClientePorCidade) : base(notificationHandler)
        {
            _mediatorHandler = mediatorHandler;
            _mapper = mapper;
            _clienteRepositorio = clienteRepositorio;
            _consultaDeClientePorCidade = consultaDeClientePorCidade;
        }

        [HttpPost]
        [ProducesResponseType(typeof(bool), 201)]
        public async Task<IActionResult> CadastrarCliente([FromBody] ClienteViewModel cliente)
        {
            var command = _mapper.Map<CadastrarClienteCommand>(cliente);

            return Response(await _mediatorHandler.EnviarComando<CadastrarClienteCommand, bool>(command));
        }

        [HttpGet("enderecos-clientes")]
        public async Task<IActionResult> ObterEnderecosClientes()
        {
            return Ok(await _clienteRepositorio.ObterEnderecosClientes());
        }

        [HttpGet]
        public async Task<IActionResult> ObterClientes()
        {
            return Ok(await _clienteRepositorio.ObterClientes());
        }

        [HttpGet("cidade/{cidade}")]
        public async Task<IActionResult> ObterClientePorCidade(string cidade)
        {
            return Ok(await _consultaDeClientePorCidade.ConsultarClientePorCidade(cidade));
        }
    }
}
