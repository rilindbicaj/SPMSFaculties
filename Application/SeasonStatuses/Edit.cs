using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Persistence;
using System;
using Domain;
using System.Collections.Generic;

namespace Application.SeasonStatuses
{
    public class Edit
    {
        public class Command : IRequest
        {
        public int SeasonStatusID { get; set; }

        public string Status { get; set; }

        public ICollection<SemesterRegisteringSeason> Seasons { get; set; }
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
                var seasonstatus = await _context.SeasonStatuses.FindAsync(request.SeasonStatusID);

                if(seasonstatus == null)
                    throw new Exception ("Could not find seasonstatuses");

                seasonstatus.Status = request.Status ?? seasonstatus.Status;
                seasonstatus.Seasons = request.Seasons ?? seasonstatus.Seasons;
                

                var success = await _context.SaveChangesAsync() > 0;
        
                if(success) return Unit.Value;
        
                throw new Exception ("Problem saving changes");
            }
        }
    }
}

