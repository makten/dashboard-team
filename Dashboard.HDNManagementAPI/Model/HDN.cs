using System;

namespace Dashboard.HDNManagementAPI.Model
{
    public class HDN
    {
        public int HdnId { get; set; }
        public string BerichtNaam { get; set; }
        public string BerichtLocatie { get; set; }
        public HdnOption HdnOption { get; set; }
        public Omgeving Omgeving { get; set; }
    }
}
