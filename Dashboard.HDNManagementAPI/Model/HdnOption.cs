using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.HDNManagementAPI.Model
{
    public class HdnOption
    {
        public int HdnOptionId { get; set; }
        public SoortHypotheek TypeOfHypotheek { get; set; }
        public bool UseNHG { get; set; }
        public bool UseGivenFirstClient { get; set; }
        public bool UseGivenSecondClient { get; set; }
        public bool UseGivenTussenPersoon { get; set; }
        public bool UseOverbruggingBedrag { get; set; }
        public string FirstClientName { get; set; }
        public string SecondClientName { get; set; }
        public string TussenPersoon { get; set; }
        public string OverbruggingBedrag { get; set; }
    }

    public enum SoortHypotheek
    {
        [Description("Eerste Hypotheek")]
        EersteHypotheek = 1,
        [Description("Tweede Hypotheek")]
        TweedeHypotheek = 2
    }
}


