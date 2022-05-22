using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Persistence;
using Domain;
using System;
using System.Collections.Generic;

namespace Application.Majors
{
    public class Create
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
                var major = new Major
                {
                    MajorID = request.MajorID,
                    MajorName = request.MajorName,
                    Faculties = request.Faculties,

                };

                _context.Majors.Add(major);
                var success = await _context.SaveChangesAsync() > 0;

                if(success) return Unit.Value;

                throw new Exception ("Problem saving changes");
            }
        }
    }
}


