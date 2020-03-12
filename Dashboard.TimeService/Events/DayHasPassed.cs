using System;
using CCMS.Infrastructure.MessageQueue.Models;

namespace Dashboard.TimeService.Events
{
    public class DayHasPassed : Event
    {
        public DayHasPassed(Guid messageId) : base(messageId) { }
    }
}
