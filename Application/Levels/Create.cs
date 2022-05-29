using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Persistence;
using Domain;
using System;
using System.Collections.Generic;
using AutoMapper;

namespace Application.Levels
{
    public class Create
    {
        public class Command : IRequest
        {
        public Level Level { get; set; }

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
                 var level = await _context.Levels.FindAsync(request.Level);

                 _mapper.Map(request.Level, level);

                _context.Levels.Add(level);
                var success = await _context.SaveChangesAsync() > 0;

                if(success) return Unit.Value;

                throw new Exception ("Problem saving changes");
            }
        }
    }
}
