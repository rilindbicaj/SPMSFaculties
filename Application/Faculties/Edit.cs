using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Persistence;
using System;
using Domain;
using System.Collections.Generic;

namespace Application.Faculties
{
    public class Edit
    {
        public class Command : IRequest
        {
        public int FacultyID {get; set;}
        public string FacultyName {get; set;}
        public int MajorID {get; set;}
        public int LevelID {get; set;}
        public Major Major { get; set; }
        public Level Level { get; set; }
        public virtual ICollection<FacultySemester> FacultySemesters { get; set; }

        public virtual ICollection<UserFaculty> UserFaculties { get; set; }
        }
        
        public class Handler : IRequestHandler<Command>
        {
            private readonly FacultyDBContext _context;
        
            public Handler(FacultyDBContext context)
            {
                _context = context;
            }
        
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var faculty = await _context.Faculties.FindAsync(request.FacultyID);

                if(faculty == null)
                    throw new Exception ("Could not find faculty");

                faculty.FacultyName = request.FacultyName ?? faculty.FacultyName;
                faculty.MajorID = request.MajorID;   // To be corrected
                faculty.LevelID = request.LevelID;  // To be corrected
                faculty.Major = request.Major ?? faculty.Major;
                faculty.Level = request.Level ?? faculty.Level;
                faculty.FacultySemesters = request.FacultySemesters ?? faculty.FacultySemesters;
                faculty.UserFaculties = request.UserFaculties ?? faculty.UserFaculties;
                

                var success = await _context.SaveChangesAsync() > 0;
        
                if(success) return Unit.Value;
        
                throw new Exception ("Problem saving changes");
            }
        }
    }
}