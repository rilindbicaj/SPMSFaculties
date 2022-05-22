using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Levels
{
    public class ListLevels
    {
        public class Query : IRequest<List<Level>> {}

        public class Handler : IRequestHandler<Query, List<Level>>
        {
            private readonly FacultyDBContext _context;

            public Handler(FacultyDBContext context)
            {
                _context = context;
            }

            public async Task<List<Level>> Handle (Query request, CancellationToken cancellationToken)
            {
                var levels = await _context.Levels.ToListAsync();

                return levels;
            }
        }
    }
}