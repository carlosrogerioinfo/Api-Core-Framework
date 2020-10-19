using System;
using FluentValidator;

namespace InVivo.Shared.Entities
{
    //Classe que será herdada pelas entidades e implementará as notificações

    public abstract class Entity: Notifiable
    {

        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }

    }
}
