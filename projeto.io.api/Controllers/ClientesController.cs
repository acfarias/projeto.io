using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using projeto.io.api.ViewModel.Cliente;
using projeto.io.domain.Clientes.Commands;
using projeto.io.domain.Interfaces;
using System.Threading.Tasks;

namespace projeto.io.api.Controllers
{
    [Route("clientes")]
    [ApiController]
    public class ClientesController : Controller
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IMapper _mapper;

        public ClientesController(IMediatorHandler mediatorHandler, IMapper mapper)
        {
            _mediatorHandler = mediatorHandler;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(bool), 201)]
        public async Task<IActionResult> CadastrarCliente([FromBody] ClienteViewModel cliente)
        {
            var command = _mapper.Map<CadastrarClienteCommand>(cliente);

            return Created(string.Empty, await _mediatorHandler.EnviarComando<CadastrarClienteCommand, bool>(command));
        }
    }
}
