﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Dashboard.Infrastructure.MessageQueue.Models
{
    public class Command : Message
    {
        public Command() { }
        public Command(Guid messageId) : base(messageId) { }
        public Command(string messageType) : base(messageType) { }
        public Command(Guid messageId, string messageType) : base(messageId, messageType) { }

    }
}
