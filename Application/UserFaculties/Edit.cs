using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Persistence;
using System;
using Domain;
using System.Collections.Generic;

namespace Application.UserFaculties
{
    public class Edit
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
                var userfaculty = await _context.UserFaculties.FindAsync(request.UserID);

                if(userfaculty == null)
                    throw new Exception ("Could not find userfaculties");

                userfaculty.FacultyID = request.FacultyID; // Operator '??' cannot be applied to operands of type 'int' and 'int'
                userfaculty.Faculty = request.Faculty ?? userfaculty.Faculty;
                

                var success = await _context.SaveChangesAsync() > 0;
        
                if(success) return Unit.Value;
        
                throw new Exception ("Problem saving changes");
            }
        }
    }
}

