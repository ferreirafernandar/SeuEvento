using System;
using FluentValidation.Results;
using SeuEvento.Domain.Core.Bus;
using SeuEvento.Domain.Core.Notifications;
using SeuEvento.Domain.Interfaces;

namespace SeuEvento.Domain.CommandHandlers
{
    public class CommandHandler
    {
        private readonly IBus _bus;
        private readonly IDomainNotificationHandler<DomainNotification> _notifications;
        private readonly IUnitOfWork _uow;

        protected CommandHandler(IUnitOfWork uow, IBus bus, IDomainNotificationHandler<DomainNotification> notifications)
        {
            _uow = uow;
            _bus = bus;
            _notifications = notifications;
        }

        protected void NotificarValidacoesErro(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Console.WriteLine(error.ErrorMessage);
                _bus.RaiseEvent(new DomainNotification(error.PropertyName, error.ErrorMessage));
            }
        }

        protected bool Commit()
        {
            if (_notifications.HasNotifications()) return false;
            var commandResponse = _uow.Commit();
            if (commandResponse.Success) return true;

            _bus.RaiseEvent(new DomainNotification("Commit", "Ocorreu um erro ao salvar os dados no banco."));
            return false;
        }
    }
}