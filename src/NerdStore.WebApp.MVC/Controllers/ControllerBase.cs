using MediatR;
using Microsoft.AspNetCore.Mvc;
using NerdStore.Core.Comunication.Mediator;
using NerdStore.Core.Messages.CommonMessages.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NerdStore.WebApp.MVC.Controllers
{
    public abstract class ControllerBase : Controller
    {
        private readonly DomainNotificationHandler _notifications;
        private readonly IMediatorHandler _mediatorHandler;

        protected Guid ClienteId = Guid.Parse("35ec21d9-fe65-4bdd-8683-064676ec4f4c");

        protected ControllerBase(INotificationHandler<DomainNotification> notifications, IMediatorHandler mediatorHandler)
        {
            _notifications = (DomainNotificationHandler)notifications;
            _mediatorHandler = mediatorHandler;
        }


        protected bool OperacaoValida() => !_notifications.TemNotificacao();

        protected IEnumerable<string> ObterMensagensErro() => _notifications.ObterNotificacoes().Select(_ => _.Value).ToList();

        protected void NotificarErro(string codigo, string mensagem) => _mediatorHandler.PublicarNotificacao(new DomainNotification(codigo, mensagem));
    }
}