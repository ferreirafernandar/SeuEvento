using System;
using FluentValidation.Results;
using SeuEvento.Domain.Core.Bus;
using SeuEvento.Domain.Core.Notifications;
using SeuEvento.Domain.Eventos.Repository;

namespace SeuEvento.Domain.CommandHandlers
{
    public class CommandHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IBus _bus;
        private readonly IDomainNotificationHandler<DomainNotification> _notifications;

        protected CommandHandler(IUnitOfWork uow, IBus bus, IDomainNotificationHandler<DomainNotification> notifications)
        {
            _uow = uow;
            _bus = bus;
            _notifications = notifications;
        }

        protected void NotificarValicacoesErro(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Console.WriteLine(error.ErrorMessage);
                _bus.RaiseEvent(new DomainNotification(error.PropertyName, error.ErrorMessage));
            }
        }

        protected bool Commit()
        {
            if (_notifications.HasNotification()) return false;
            var commandResponse = _uow.Commit();
            if (commandResponse.Success) return true;

            _bus.RaiseEvent(new DomainNotification("Commit", "Ocorreu um erro ao salvar os dados no banco."));
            return false;
        }
    }
}