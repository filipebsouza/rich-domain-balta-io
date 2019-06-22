using System;
using Flunt.Notifications;

namespace Shared.Entities.Shared
{
    public abstract class Entity : Notifiable
    {
        public Entity(Guid id)
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
    }
}