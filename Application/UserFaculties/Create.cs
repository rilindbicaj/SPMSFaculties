using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Persistence;
using Domain;
using System;
using System.Collections.Generic;

namespace Application.UserFaculties
{
    public class Create
    {
        public class Command : IRequest
        {
        public Guid UserID { get; set; }
        public int FacultyID { get; set; }

        public Faculty Faculty { get; set;}
        
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
                var userfaculty = new UserFaculty
                {
                    UserID = request.UserID,
                    FacultyID = request.FacultyID,
                    Faculty = request.Faculty,

                };

                _context.UserFaculties.Add(userfaculty);
                var success = await _context.SaveChangesAsync() > 0;

                if(success) return Unit.Value;

                throw new Exception ("Problem saving changes");
            }
        }
    }
}


