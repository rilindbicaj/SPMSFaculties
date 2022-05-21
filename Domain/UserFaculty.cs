using System;
using System.Collections;
using System.Collections.Generic;

namespace Domain
{
    public class UserFaculty
    {
        public Guid UserID { get; set; }
        public int FacultyID { get; set; }

        public Faculty Faculty { get; set; }

    }
}