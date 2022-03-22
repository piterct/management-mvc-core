using Flunt.Notifications;
using Gestao.Business.Commands.Shared;
using Gestao.Business.Interfaces;
using Gestao.Business.Notificacoes;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Gestao.App.Controllers
{
    public abstract class BaseController : Controller
    {
        private readonly INotificador _notificador;

        public BaseController(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected bool OperacaoValida()
        {
            return !_notificador.TemNotificacao();
        }

        protected bool ValidaCommand<TE>(TE entidade) where TE : CommandEntity
        {
            entidade.Validate();
            if (entidade.Valid) return true;

            NotificarErroCommandInvalido(entidade.Notifications);

            return false;

        }

        protected void NotificarErroCommandInvalido(IReadOnlyCollection<Notification> notificacoes)
        {
            foreach(var erro in notificacoes)
            {
                _notificador.Handle(new Notificacao(erro.Message));
            }
        }
    }
}
