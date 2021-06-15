using FluentValidation.Results;
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

        protected void NotificarValidacoesErros(ValidationResult validationResult)
        {
            validationResult.Errors.ForEach(e => _mediatorHandler.PublicarEvento(new DomainNotification(e.PropertyName, e.ErrorMessage)));
        }
    }
}
