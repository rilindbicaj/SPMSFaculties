using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Persistence;
using System;
using Domain;
using AutoMapper;

namespace Application.Levels
{
    public class Edit
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
                var level = await _context.Levels.FindAsync(request.Level.LevelID);

                if(level == null)
                    throw new Exception ("Could not find levels");

                      _mapper.Map(request.Level, level);
                

                var success = await _context.SaveChangesAsync() > 0;
        
                if(success) return Unit.Value;
        
                throw new Exception ("Problem saving changes");
            }

        }
    }
}