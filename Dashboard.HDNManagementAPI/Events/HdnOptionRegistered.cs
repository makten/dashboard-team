using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CCMS.Infrastructure.MessageQueue.Models;
using Dashboard.HDNManagementAPI.Model;

namespace Dashboard.HDNManagementAPI.Events
{
    public class HdnOptionRegistered : Event
    {
        public int HdnOptionId;
        public SoortHypotheek TypeOfHypotheek;
        public bool UseNHG;
        public bool UseGivenFirstClient;
        public bool UseGivenSecondClient;
        public bool UseGivenTussenPersoon;
        public bool UseOverbruggingBedrag;
        public string FirstClientName;
        public string SecondClientName;
        public string TussenPersoon;
        public string OverbruggingBedrag;

        public HdnOptionRegistered(Guid messageId)
        {
            
        }
    }
}
