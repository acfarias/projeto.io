using MediatR;
using Microsoft.AspNetCore.Mvc;
using projeto.io.domain.core.Notifications;

namespace projeto.io.api.Controllers
{
    public abstract class BaseController : Controller
    {
        private readonly DomainNotificationHandler _domainNotificationHandler;

        public BaseController(INotificationHandler<DomainNotification> notificationHandler)
        {
            _domainNotificationHandler = (DomainNotificationHandler)notificationHandler;
        }

        protected new IActionResult Response(object result = null)
        {
            if (OperacaoValida())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                erros = _domainNotificationHandler.ObterNotificacoes()
            });
        }

        protected bool OperacaoValida()
        {
            return (!_domainNotificationHandler.ExisteNotificacoes());
        }
    }
}
