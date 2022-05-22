using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Persistence;
using System;
using Domain;
using System.Collections.Generic;

namespace Application.FacultySemesters
{
    public class Edit
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
                var facultysemester = await _context.FacultySemesters.FindAsync(request.FacultyID);

                if(facultysemester == null)
                    throw new Exception ("Could not find faculty");

                facultysemester.Faculty = request.Faculty ?? facultysemester.Faculty;
                facultysemester.Semester = request.Semester ?? facultysemester.Semester;
                facultysemester.RegisteringSeasons = request.RegisteringSeasons ?? facultysemester.RegisteringSeasons;

                

                var success = await _context.SaveChangesAsync() > 0;
        
                if(success) return Unit.Value;
        
                throw new Exception ("Problem saving changes");
            }
        }
    }
}