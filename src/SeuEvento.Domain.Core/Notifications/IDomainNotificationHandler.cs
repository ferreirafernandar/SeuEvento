using System.Collections.Generic;
using SeuEvento.Domain.Core.Events;

namespace SeuEvento.Domain.Core.Notifications
{
    public interface IDomainNotificationHandler<T> : IHandler<T> where T : Message
    {
        bool HasNotifications();
        List<T> GetNotifications();
    }
}