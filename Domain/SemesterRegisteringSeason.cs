using System;
using System.Collections;
using System.Collections.Generic;

namespace Domain
{
    public class SemesterRegisteringSeason
    {
        public int SemesterRegisteringSeasonID { get; set; }
        public string RegisteringSeasonName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CurrentStatus { get; set; }
        public int Faculty { get; set; }
        public int Semester { get; set; }

        public FacultySemester FacultySemester { get; set; }
        public ICollection<RegisteredSemester> RegisteredSemesters { get; set; }
        public SeasonStatus SeasonStatus { get; set; }

    }
}