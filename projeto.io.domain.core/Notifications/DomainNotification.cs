using MediatR;

namespace projeto.io.domain.core.Notifications
{
    public class DomainNotification : INotification
    {
        public DomainNotification(string codigo, string mensagem)
        {
            Codigo = codigo;
            Mensagem = mensagem;
        }

        public string Codigo { get; private set; }
        public string Mensagem { get; private set; }
    }
}
