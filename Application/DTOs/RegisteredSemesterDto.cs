using System;
using Microsoft.VisualBasic;

namespace Application.DTOs
{
    public class RegisteredSemesterDto
    {
        public int RegistrationID { get; set; }
        public int StudentID { get; set; }
        public int RegisteringSeasonID { get; set; }
        public DateTime DateRegistered { get; set; }

    }
}