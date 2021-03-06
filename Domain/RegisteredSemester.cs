using System;
using Microsoft.VisualBasic;

namespace Domain
{
    public class RegisteredSemester
    {
        public int RegistrationID { get; set; }
        //public Guid StudentID { get; set; }
        public int RegisteringSeasonID { get; set; }
        public Guid Student { get; set; }
        public DateTime DateRegistered { get; set; }

        public SemesterRegisteringSeason SemesterRegisteringSeason { get; set; }

    }
}