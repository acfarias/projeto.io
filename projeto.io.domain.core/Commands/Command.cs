using FluentValidation.Results;
using MediatR;

namespace projeto.io.domain.core.Commands
{
    public abstract class Command<TResponse> : IRequest<TResponse>
    {
        public ValidationResult ValidationResult { get; set; }

        public abstract bool IsValid();
    }
}
