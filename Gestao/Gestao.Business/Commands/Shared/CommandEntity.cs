using Flunt.Notifications;
using Gestao.Business.Commands.Interfaces;

namespace Gestao.Business.Commands.Shared
{
    public abstract  class CommandEntity :  Notifiable, ICommand
    {
        public abstract void Validate();
    }
}
