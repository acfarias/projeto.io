using MediatR;
using projeto.io.domain.core.Commands;
using System.Threading.Tasks;

namespace projeto.io.domain.Interfaces
{
    public interface IMediatorHandler
    {
        Task<TResponse> EnviarComando<TRequest, TResponse>(TRequest comando) where TRequest : Command<TResponse>;
        Task PublicarEvento<T>(T evento) where T : INotification;
    }
}
