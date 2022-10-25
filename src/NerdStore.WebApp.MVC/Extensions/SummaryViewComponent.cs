using MediatR;
using Microsoft.AspNetCore.Mvc;
using NerdStore.Core.Messages.CommonMessages.Notifications;
using System.Threading.Tasks;

namespace NerdStore.WebApp.MVC.Extensions
{
    public class SummaryViewComponent : ViewComponent
    {
        private readonly DomainNotificationHandler _notifications;

        public SummaryViewComponent(INotificationHandler<DomainNotification> notifications)
        {
            _notifications = (DomainNotificationHandler)notifications;
        }

        public async Task<IViewComponentResult> InvoikeAsync()
        {
            var notifications = await Task.FromResult(_notifications.ObterNotificacoes());
            notifications.ForEach(_ => ViewData.ModelState.AddModelError(string.Empty, _.Value));

            return View();
        }
    }
}
