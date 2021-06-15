using MediatR;
using projeto.io.domain.core.Commands;
using projeto.io.domain.Interfaces;
using System.Threading.Tasks;

namespace projeto.io.domain.Handlers
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<TResponse> EnviarComando<TRequest, TResponse>(TRequest comando) where TRequest : Command<TResponse>
        {
            return await _mediator.Send(comando);
        }

        public async Task PublicarEvento<T>(T evento) where T : INotification
        {
            await _mediator.Publish(evento);
        }
    }
}
