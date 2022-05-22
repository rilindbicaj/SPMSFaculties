using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Persistence;
using System;
using Domain;
using System.Collections.Generic;

namespace Application.Semesters
{
    public class Edit
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
                var semester = await _context.Semesters.FindAsync(request.SemesterID);

                if(semester == null)
                    throw new Exception ("Could not find semesters");

                semester.SemesterID = request.SemesterID;   // To be corrected
                semester.FacultySemesters = request.FacultySemesters ?? semester.FacultySemesters;
                semester.SemesterName = request.SemesterName ?? semester.SemesterName;
                

                var success = await _context.SaveChangesAsync() > 0;
        
                if(success) return Unit.Value;
        
                throw new Exception ("Problem saving changes");
            }
        }
    }
}

