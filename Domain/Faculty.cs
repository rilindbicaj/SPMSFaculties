using System.Collections.Generic;

namespace Domain
{
    public class Faculty
    {
        public int FacultyID { get; set; }
        public string FacultyName { get; set; }
        public int MajorID { get; set; }
        public int LevelID { get; set; }

        public Major Major { get; set; }
        public Level Level { get; set; }
        public virtual ICollection<FacultySemester> FacultySemesters { get; set; }

        public virtual ICollection<UserFaculty> UserFaculties { get; set; }

    }
}