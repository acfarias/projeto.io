using System;

namespace projeto.io.domain.core.Modelos
{
    public abstract class Entity<T> where T : class
    {
        public Guid Id { get; protected set; }
    }
}
