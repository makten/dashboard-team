using System;
using System.Collections.Generic;
using System.Text;

namespace Dashboard.Infrastructure.MessageQueue.Models
{
    public class Message
    {
        public readonly Guid MessageId;
        public readonly string MessageType;

        public Message() : this(Guid.NewGuid()) { }

        public Message(Guid messageId)
        {
            MessageId = messageId;
            MessageType = this.GetType().Name;
        }

        public Message(string messageType)
        {
            MessageType = messageType;
        }

        public Message(Guid messageId, string messageType)
        {
            MessageType = messageType;
            MessageId = messageId;
        }
    }
}
