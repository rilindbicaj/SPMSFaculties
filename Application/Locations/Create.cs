using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Persistence;
using Domain;
using System;
using System.Collections.Generic;

namespace Application.Locations
{
    public class Create
    {
        public class Command : IRequest
        {
        public int LocationID {get; set;}
        public string LocationName {get; set;}

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
                var location = new Location
                {
                    LocationID = request.LocationID,
                    LocationName = request.LocationName,

                };

                _context.Locations.Add(location);
                var success = await _context.SaveChangesAsync() > 0;

                if(success) return Unit.Value;

                throw new Exception ("Problem saving changes");
            }
        }
    }
}
