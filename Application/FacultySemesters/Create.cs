using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Persistence;
using Domain;
using System;
using System.Collections.Generic;

namespace Application.FacultySemesters
{
    public class Create
    {
        public class Command : IRequest
        {
        public int FacultyID {get; set;}
        public int SemesterID {get; set;}
        public virtual Faculty Faculty { get; set; }
        public virtual Semester Semester { get; set; }
        public virtual ICollection<SemesterRegisteringSeason> RegisteringSeasons { get; set; }

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
                var facultysemester = new FacultySemester
                {
                    FacultyID = request.FacultyID,
                    SemesterID = request.SemesterID,
                    Faculty = request.Faculty,
                    Semester = request.Semester,
                    RegisteringSeasons = request.RegisteringSeasons,
                };

                _context.FacultySemesters.Add(facultysemester);
                var success = await _context.SaveChangesAsync() > 0;

                if(success) return Unit.Value;

                throw new Exception ("Problem saving changes");
            }
        }
    }
}
