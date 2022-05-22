using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Levels
{
    public class Details
    {
        public class Query : IRequest <Level>
        {
            public int LevelID {get; set;}
        }

        public class Handler : IRequestHandler<Query, Level>
        {
            private readonly FacultyDBContext _context;

            public Handler(FacultyDBContext context)
            {
                _context = context;   
            }

            public async Task<Level> Handle(Query request, CancellationToken cancellationToken)
            {
                var level = await _context.Levels.FindAsync(request.LevelID);

                return level;
            }
        }

    }
}