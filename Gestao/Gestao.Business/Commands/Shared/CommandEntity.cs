using Flunt.Notifications;
using Gestao.Business.Commands.Interfaces;
using System;

namespace Gestao.Business.Commands.Shared
{
    public abstract  class CommandEntity :  Notifiable, ICommand
    {
        public CommandEntity()
        {
            CommandId = Guid.NewGuid();
        }
        public Guid CommandId { get; set; }
        public abstract void Validate();
    }
}
