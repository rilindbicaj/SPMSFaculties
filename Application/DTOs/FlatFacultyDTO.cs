using System.Collections.Generic;
using Domain;

namespace Application.DTOs
{
    public class FlatFacultyDTO
    {
        public int FacultyID { get; set; }
        public string FacultyName { get; set; }
        public int MajorID { get; set; }
        public int LevelID { get; set; }
        public string Major { get; set; }
        public string Level { get; set; }

    }
}