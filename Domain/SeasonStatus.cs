using System.Collections.Generic;

namespace Domain
{
    public class SeasonStatus
    {
        public int SeasonStatusID { get; set; }

        public string Status { get; set; }

        public ICollection<SemesterRegisteringSeason> Seasons { get; set; }
    }
}