using System;

namespace Application.DTOs
{
    public class SemesterRegisteringSeasonDto
    {
        public int SemesterRegisteringSeasonID { get; set; }
        public string RegisteringSeasonName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CurrentStatus { get; set; }
        public int Faculty { get; set; }
        public int Semester { get; set; }

    }
}