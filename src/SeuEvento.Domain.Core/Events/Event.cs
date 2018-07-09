using System;

namespace SeuEvento.Domain.Core.Events
{
    public class Event : Message
    {
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
}