using AutoMapper;
using MediatR;
using projeto.io.domain.Commands.Clientes.Entities;
using projeto.io.domain.Commands.Clientes.Repositorio;
using projeto.io.domain.core.Notifications;
using projeto.io.domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace projeto.io.domain.Commands.Clientes.Commands
{
    public class ClienteCommandHandler : CommandHandler,
                                       IRequestHandler<CadastrarClienteCommand, bool>,
                                       IRequestHandler<AtualizarClienteCommand, bool>,
                                       IRequestHandler<ExcluirClienteCommand, bool>
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IMapper _mapper;
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly IEnderecoDoClienteRepositorio _enderecoDoClienteRepositorio;

        public ClienteCommandHandler(IMediatorHandler mediatorHandler,
                                     IMapper mapper,
                                     IClienteRepositorio clienteRepositorio,
                                     IEnderecoDoClienteRepositorio enderecoDoClienteRepositorio) : base(mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
            _mapper = mapper;
            _clienteRepositorio = clienteRepositorio;
            _enderecoDoClienteRepositorio = enderecoDoClienteRepositorio;
        }

        public async Task<bool> Handle(CadastrarClienteCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotificarValidacoesErros(request);
                return false;
            }

            var clienteExistente = await _clienteRepositorio.ObterPorCpf(request.Cpf.CPF);
            if (clienteExistente != null)
            {
                await _mediatorHandler.PublicarEvento(new DomainNotification("", "Já existe cliente cadastrado com o Cpf informado."));
                return false;
            }

            var enderecoMapper = _mapper.Map<EnderecoCliente>(request.Endereco);
            var cadastroEndereco = await _enderecoDoClienteRepositorio.Cadastrar(enderecoMapper);
            if (cadastroEndereco != 1)
            {
                await _mediatorHandler.PublicarEvento(new DomainNotification("", "Falha ao cadastrar Endereço do cliente."));
                return false;
            }

            var cliente = _mapper.Map<Tuple<Guid, CadastrarClienteCommand>, Cliente>(Tuple.Create(enderecoMapper.Id, request));
            await _clienteRepositorio.Cadastrar(cliente);

            return true;
        }

        public async Task<bool> Handle(AtualizarClienteCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotificarValidacoesErros(request);
                return false;
            }

            var clienteExistente = await _clienteRepositorio.ObterPorId(request.Id);
            if (clienteExistente == null)
            {
                await _mediatorHandler.PublicarEvento(new DomainNotification("", "Cliente não localizado na base de dados."));
                return false;
            }

            var cliente = _mapper.Map<Cliente>(request);
            await _clienteRepositorio.Atualizar(cliente);

            return true;
        }

        public async Task<bool> Handle(ExcluirClienteCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotificarValidacoesErros(request);
                return false;
            }

            var clienteExistente = await _clienteRepositorio.ObterPorId(request.Id);
            if (clienteExistente == null)
            {
                await _mediatorHandler.PublicarEvento(new DomainNotification("", "Cliente não localizado na base de dados."));
                return false;
            }

            await _clienteRepositorio.Excluir(clienteExistente);

            return true;
        }
    }
}
