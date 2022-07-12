using System.Collections.Generic;
using Domain;

namespace Application.DTOs
{
    public class FlatFacultyDTO
    {
        public int FacultyID { get; set; }
        public string FacultyName { get; set; }
        public MajorDto Major { get; set; }
        public LevelDto Level { get; set; }
        public ICollection<SemesterDto> Semesters { get; set; }

    }
}