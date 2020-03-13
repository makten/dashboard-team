using System;
using System.Collections.Generic;
using CCMS.Infrastructure.MessageQueue.Models;
using Dashboard.HDNManagementAPI.Model;

namespace Dashboard.HDNManagementAPI.Events
{
    public class OmgevingRegistered : Event
    {
        public int OmgevingId;
        public string OmgevingNaam;
        public string Description;
        public IEnumerable<Label> Labels;
        public OmgevingRegistered(Guid messageId, int omgevingId, string omgevingNaam, string description, IEnumerable<Label> labels)
        {
            OmgevingId = omgevingId;
            OmgevingNaam = omgevingNaam;
            Description = description;
            Labels = labels;
        }
    }
}
