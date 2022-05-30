using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Persistence;
using System;
using AutoMapper;

namespace Application.SeasonStatuses
{
    public class Delete
    {
        public class Command : IRequest
        {
            public int SeasonStatusID {get; set;}
        }

        public class Handler : IRequestHandler<Command>
        {
             private readonly FacultyDBContext _context;
             private readonly IMapper _mapper;

            public Handler(FacultyDBContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var seasonstatus = await _context.SeasonStatuses.FindAsync(request.SeasonStatusID);

                if(seasonstatus == null)
                    throw new Exception("Could not find seasonstatus");

                _context.Remove(seasonstatus);

                var success = await _context.SaveChangesAsync() > 0;

                if(success) return Unit.Value;

                throw new Exception ("Problem saving changes");
            }
        }
    }
}

