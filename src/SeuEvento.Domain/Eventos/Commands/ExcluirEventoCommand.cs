using System;

namespace SeuEvento.Domain.Eventos.Commands
{
    public class ExcluirEventoCommand : BaseEventoCommand
    {
        public ExcluirEventoCommand(Guid id)
        {
            Id = id;
            AggregateId = Id;
        }
    }
}