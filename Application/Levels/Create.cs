using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Persistence;
using Domain;
using System;
using System.Collections.Generic;

namespace Application.Levels
{
    public class Create
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
                var level = new Level
                {
                    LevelID = request.LevelID,
                    LevelName = request.LevelName,
                    Faculties = request.Faculties,

                };

                _context.Levels.Add(level);
                var success = await _context.SaveChangesAsync() > 0;

                if(success) return Unit.Value;

                throw new Exception ("Problem saving changes");
            }
        }
    }
}
