using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Persistence;
using Domain;
using System;
using System.Collections.Generic;

namespace Application.SeasonStatuses
{
    public class Create
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
                var seasonstatus = new SeasonStatus
                {
                    SeasonStatusID = request.SeasonStatusID,
                    Status = request.Status,
                    Seasons = request.Seasons,

                };

                _context.SeasonStatuses.Add(seasonstatus);
                var success = await _context.SaveChangesAsync() > 0;

                if(success) return Unit.Value;

                throw new Exception ("Problem saving changes");
            }
        }
    }
}


