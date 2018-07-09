using System;
using SeuEvento.Domain.Core.Events;

namespace SeuEvento.Domain.Core.Commands
{
    public class Command : Message
    {
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
}