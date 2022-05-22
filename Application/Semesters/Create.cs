using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Persistence;
using Domain;
using System;
using System.Collections.Generic;

namespace Application.Semesters
{
    public class Create
    {
        public class Command : IRequest
        {
        public int SemesterID {get; set;}
        public string SemesterName {get; set;}
        public virtual ICollection<FacultySemester> FacultySemesters { get; set; }

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
                var semester = new Semester
                {
                    SemesterID = request.SemesterID,
                    SemesterName = request.SemesterName,
                    FacultySemesters = request.FacultySemesters,

                };

                _context.Semesters.Add(semester);
                var success = await _context.SaveChangesAsync() > 0;

                if(success) return Unit.Value;

                throw new Exception ("Problem saving changes");
            }
        }
    }
}


