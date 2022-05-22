using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Persistence;
using System;
using Domain;
using System.Collections.Generic;

namespace Application.RegisteredSemesters
{
    public class Edit
    {
        public class Command : IRequest
        {
        public int RegistrationID { get; set; }
        public int StudentID { get; set; }
        public int RegisteringSeasonID { get; set; }
        public DateTime DateRegistered { get; set; }
        public SemesterRegisteringSeason SemesterRegisteringSeason { get; set; }
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
                var registeredsemester = await _context.RegisteredSemesters.FindAsync(request.RegistrationID);

                if(registeredsemester == null)
                    throw new Exception ("Could not find registeredsemesters");

                registeredsemester.StudentID = request.StudentID; // To be corrected
                registeredsemester.RegisteringSeasonID = request.RegisteringSeasonID; // To be corrected
                registeredsemester.DateRegistered = request.DateRegistered;  // To be corrected
                registeredsemester.SemesterRegisteringSeason = request.SemesterRegisteringSeason ?? registeredsemester.SemesterRegisteringSeason;
                

                var success = await _context.SaveChangesAsync() > 0;
        
                if(success) return Unit.Value;
        
                throw new Exception ("Problem saving changes");
            }
        }
    }
}

