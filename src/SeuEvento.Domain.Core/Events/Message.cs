using System;

namespace SeuEvento.Domain.Core.Events
{
    public class Message
    {
        protected Message() => MessageType = GetType().Name;

        public string MessageType { get; protected set; }
        public Guid AggregateId { get; protected set; }
    }
}