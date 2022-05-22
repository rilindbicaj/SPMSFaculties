using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Faculties
{
    public class Details
    {
        public class Query : IRequest <Faculty>
        {
            public int FacultyID {get; set;}
        }

        public class Handler : IRequestHandler<Query, Faculty>
        {
            private readonly FacultyDBContext _context;

            public Handler(FacultyDBContext context)
            {
                _context = context;   
            }

            public async Task<Faculty> Handle(Query request, CancellationToken cancellationToken)
            {
                var faculty = await _context.Faculties.FindAsync(request.FacultyID);

                return faculty;
            }
        }

    }
}