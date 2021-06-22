using projeto.io.domain.core.Commands;
using projeto.io.domain.core.Notifications;

namespace projeto.io.domain.Interfaces
{
    public abstract class CommandHandler
    {
        private readonly IMediatorHandler _mediatorHandler;

        public CommandHandler(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        protected void NotificarValidacoesErros<TResult>(Command<TResult> command)
        {
            command.ValidationResult.Errors.ForEach(e => _mediatorHandler.PublicarEvento(new DomainNotification(e.PropertyName, e.ErrorMessage)));
        }
    }
}
