using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.SeasonStatuses
{
    public class ListSeasonStatuses
    {
        public class Query : IRequest<List<SeasonStatus>> {}

        public class Handler : IRequestHandler<Query, List<SeasonStatus>>
        {
            private readonly FacultyDBContext _context;

            public Handler(FacultyDBContext context)
            {
                _context = context;
            }

            public async Task<List<SeasonStatus>> Handle (Query request, CancellationToken cancellationToken)
            {
                var seasonstatuses = await _context.SeasonStatuses.ToListAsync();

                return seasonstatuses;
            }
        }
    }
}

