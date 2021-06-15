using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace projeto.io.domain.core.Notifications
{
    public class DomainNotificationHandler : INotificationHandler<DomainNotification>
    {
        private List<DomainNotification> _notificacoes;

        public DomainNotificationHandler()
        {
            _notificacoes = new List<DomainNotification>();
        }

        public Task Handle(DomainNotification notification, CancellationToken cancellationToken)
        {
            _notificacoes.Add(notification);

            return Task.CompletedTask;
        }

        public virtual List<DomainNotification> ObterNotificacoes()
        {
            return _notificacoes;
        }

        public virtual bool ExisteNotificacoes()
        {
            return _notificacoes.Any();
        }
    }
}
