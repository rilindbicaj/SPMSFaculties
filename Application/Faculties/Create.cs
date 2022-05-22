using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Persistence;
using Domain;
using System;
using System.Collections.Generic;

namespace Application.Faculties
{
    public class Create
    {
        public class Command : IRequest
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

        public class Handler : IRequestHandler<Command>
        {
            private readonly FacultyDBContext _context;

            public Handler(FacultyDBContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var faculty = new Faculty
                {
                    FacultyID = request.FacultyID,
                    FacultyName = request.FacultyName,
                    MajorID = request.MajorID,
                    LevelID = request.LevelID,
                    Major = request.Major,
                    Level = request.Level,
                    FacultySemesters = request.FacultySemesters,
                    UserFaculties = request.UserFaculties,
                };

                _context.Faculties.Add(faculty);
                var success = await _context.SaveChangesAsync() > 0;

                if(success) return Unit.Value;

                throw new Exception ("Problem saving changes");
            }
        }
    }
}
