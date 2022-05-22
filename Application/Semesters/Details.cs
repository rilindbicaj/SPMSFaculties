using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Semesters
{
    public class Details
    {
        public class Query : IRequest <Semester>
        {
            public int SemesterID {get; set;}
        }

        public class Handler : IRequestHandler<Query, Semester>
        {
            private readonly FacultyDBContext _context;

            public Handler(FacultyDBContext context)
            {
                _context = context;   
            }

            public async Task<Semester> Handle(Query request, CancellationToken cancellationToken)
            {
                var semester = await _context.Semesters.FindAsync(request.SemesterID);

                return semester;
            }
        }

    }
}

