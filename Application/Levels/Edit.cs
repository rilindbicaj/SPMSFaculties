using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Persistence;
using System;
using Domain;
using System.Collections.Generic;

namespace Application.Levels
{
    public class Edit
    {
        public class Command : IRequest
        {
       public int LevelID {get; set;}
        public string LevelName {get; set;}
        public virtual ICollection<Faculty> Faculties { get; set; }
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
                var level = await _context.Levels.FindAsync(request.LevelID);

                if(level == null)
                    throw new Exception ("Could not find levels");

                level.Faculties = request.Faculties ?? level.Faculties;
                level.LevelName = request.LevelName ?? level.LevelName;
                

                var success = await _context.SaveChangesAsync() > 0;
        
                if(success) return Unit.Value;
        
                throw new Exception ("Problem saving changes");
            }
        }
    }
}