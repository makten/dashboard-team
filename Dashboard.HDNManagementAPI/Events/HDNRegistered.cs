using System;
using CCMS.Infrastructure.MessageQueue.Models;
using Dashboard.HDNManagementAPI.Model;

namespace Dashboard.HDNManagementAPI.Events
{
    public class HDNRegistered : Event
    {
        public readonly int HdnId;
        public string BerichtNaam;
        public string BerichtLocatie;
        public HdnOption HdnOption;
        public Omgeving Omgeving;
        public HDNRegistered(Guid messageId, int hdnId, string berichtNaam, string berichtLocatie, HdnOption hdnOption, Omgeving omgeving)
        {
            HdnId = hdnId;
            BerichtNaam = berichtNaam;
            BerichtLocatie = berichtLocatie;
            HdnOption = hdnOption;
            Omgeving = omgeving;
        }
    }
}
