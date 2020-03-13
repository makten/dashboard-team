using System.Collections.Generic;

namespace Dashboard.HDNManagementAPI.Model
{
    public class Omgeving
    {
        public int OmgevingId { get; set; }
        public string OmgevingNaam { get; set; }
        public string Description { get; set; }
        public IEnumerable<Label> Labels { get; set; }

        public Omgeving()
        {
            Labels = new List<Label>();
        }
    }
}
