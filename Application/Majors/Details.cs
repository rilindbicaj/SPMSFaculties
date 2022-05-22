using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Majors
{
    public class Details
    {
        public class Query : IRequest <Major>
        {
            public int MajorID {get; set;}
        }

        public class Handler : IRequestHandler<Query, Major>
        {
            private readonly FacultyDBContext _context;

            public Handler(FacultyDBContext context)
            {
                _context = context;   
            }

            public async Task<Major> Handle(Query request, CancellationToken cancellationToken)
            {
                var Major = await _context.Majors.FindAsync(request.MajorID);

                return Major;
            }
        }

    }
}

