using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Persistence;
using Domain;
using System;
using System.Collections.Generic;

namespace Application.RegisteredSemesters
{
    public class Create
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
                var registeredsemester = new RegisteredSemester
                {
                    RegistrationID = request.RegistrationID,
                    StudentID = request.StudentID,
                    RegisteringSeasonID = request.RegisteringSeasonID,
                    DateRegistered = request.DateRegistered,
                    SemesterRegisteringSeason = request.SemesterRegisteringSeason,
                };

                _context.RegisteredSemesters.Add(registeredsemester);
                var success = await _context.SaveChangesAsync() > 0;

                if(success) return Unit.Value;

                throw new Exception ("Problem saving changes");
            }
        }
    }
}
