using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.RegisteredSemesters
{
    public class ListRegisteredSemesters
    {
        public class Query : IRequest<List<RegisteredSemester>> {}

        public class Handler : IRequestHandler<Query, List<RegisteredSemester>>
        {
            private readonly FacultyDBContext _context;

            public Handler(FacultyDBContext context)
            {
                _context = context;
            }

            public async Task<List<RegisteredSemester>> Handle (Query request, CancellationToken cancellationToken)
            {
                var registeredsemesters = await _context.RegisteredSemesters.ToListAsync();

                return registeredsemesters;
            }
        }
    }
}

