using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Persistence;
using System;
using Domain;
using System.Collections.Generic;

namespace Application.Majors
{
    public class Edit
    {
        public class Command : IRequest
        {
       public int MajorID {get; set;}
        public string MajorName {get; set;}
        public virtual ICollection<Faculty> Faculties { get; set; }
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
                var major = await _context.Majors.FindAsync(request.MajorID);

                if(major == null)
                    throw new Exception ("Could not find majors");

                major.Faculties = request.Faculties ?? major.Faculties;
                major.MajorName = request.MajorName ?? major.MajorName;
                

                var success = await _context.SaveChangesAsync() > 0;
        
                if(success) return Unit.Value;
        
                throw new Exception ("Problem saving changes");
            }
        }
    }
}

