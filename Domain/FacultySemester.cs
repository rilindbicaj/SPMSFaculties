using System.Collections.Generic;

namespace Domain
{
    public class FacultySemester
    {
        public int FacultyID { get; set; }
        public int SemesterID { get; set; }

        public virtual Faculty Faculty { get; set; }
        public virtual Semester Semester { get; set; }
        public virtual ICollection<SemesterRegisteringSeason> RegisteringSeasons { get; set; }

    }
}