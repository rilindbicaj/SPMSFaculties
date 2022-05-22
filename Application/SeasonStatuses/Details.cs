using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.SeasonStatuses
{
    public class Details
    {
        public class Query : IRequest <SeasonStatus>
        {
            public int SeasonStatusID {get; set;}
        }

        public class Handler : IRequestHandler<Query, SeasonStatus>
        {
            private readonly FacultyDBContext _context;

            public Handler(FacultyDBContext context)
            {
                _context = context;   
            }

            public async Task<SeasonStatus> Handle(Query request, CancellationToken cancellationToken)
            {
                var seasonstatus = await _context.SeasonStatuses.FindAsync(request.SeasonStatusID);

                return seasonstatus;
            }
        }

    }
}

