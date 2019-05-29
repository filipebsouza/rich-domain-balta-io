using System;

namespace Shared.Entities.Shared
{
    public abstract class Entity
    {
        public Entity(Guid id)
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
    }
}