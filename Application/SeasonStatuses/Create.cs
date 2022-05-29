using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Persistence;
using Domain;
using System;
using System.Collections.Generic;
using AutoMapper;

namespace Application.SeasonStatuses
{
    public class Create
    {
        public class Command : IRequest
        {
        public SeasonStatus SeasonStatus { get; set; }

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
               var seasonstatus = await _context.SeasonStatuses.FindAsync(request.SeasonStatus);

               _mapper.Map(request.SeasonStatus, seasonstatus);

                _context.SeasonStatuses.Add(seasonstatus);
                var success = await _context.SaveChangesAsync() > 0;

                if(success) return Unit.Value;

                throw new Exception ("Problem saving changes");
            }
        }
    }
}


