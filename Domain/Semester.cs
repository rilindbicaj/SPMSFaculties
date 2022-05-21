using System.Collections.Generic;

namespace Domain
{
    public class Semester
    {
        public int SemesterID { get; set; }
        public string SemesterName { get; set; }
        public virtual ICollection<FacultySemester> FacultySemesters { get; set; }

    }
}