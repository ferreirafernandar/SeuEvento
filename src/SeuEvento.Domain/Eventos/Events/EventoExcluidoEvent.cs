using System;

namespace SeuEvento.Domain.Eventos.Events
{
    public class EventoExcluidoEvent : BaseEventoEvent
    {
        public EventoExcluidoEvent(Guid id)
        {
            Id = id;
            AggregateId = Id;
        }
    }
}