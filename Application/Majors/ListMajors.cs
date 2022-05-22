using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Majors
{
    public class ListMajors
    {
        public class Query : IRequest<List<Major>> {}

        public class Handler : IRequestHandler<Query, List<Major>>
        {
            private readonly FacultyDBContext _context;

            public Handler(FacultyDBContext context)
            {
                _context = context;
            }

            public async Task<List<Major>> Handle (Query request, CancellationToken cancellationToken)
            {
                var majors = await _context.Majors.ToListAsync();

                return majors;
            }
        }
    }
}

