using SeuEvento.Domain.Core.Commands;
using SeuEvento.Domain.Core.Events;

namespace SeuEvento.Domain.Core.Bus
{
    public interface IBus
    {
        void SendCommand<T>(T theCommand) where T : Command;
        void RaiseEvent<T>(T theEvent) where T : Event;
    }
}