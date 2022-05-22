using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Locations
{
    public class Details
    {
        public class Query : IRequest <Location>
        {
            public int LocationID {get; set;}
        }

        public class Handler : IRequestHandler<Query, Location>
        {
            private readonly FacultyDBContext _context;

            public Handler(FacultyDBContext context)
            {
                _context = context;   
            }

            public async Task<Location> Handle(Query request, CancellationToken cancellationToken)
            {
                var location = await _context.Locations.FindAsync(request.LocationID);

                return location;
            }
        }

    }
}