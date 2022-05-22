using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Persistence;
using System;
using Domain;
using System.Collections.Generic;

namespace Application.Locations
{
    public class Edit
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
                var location = await _context.Locations.FindAsync(request.LocationID);

                if(location == null)
                    throw new Exception ("Could not find locations");

                location.LocationName = request.LocationName ?? location.LocationName;

                

                var success = await _context.SaveChangesAsync() > 0;
        
                if(success) return Unit.Value;
        
                throw new Exception ("Problem saving changes");
            }
        }
    }
}