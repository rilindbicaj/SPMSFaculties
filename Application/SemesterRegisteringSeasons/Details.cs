using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.SemesterRegisteringSeasons
{
    public class Details
    {
        public class Query : IRequest <SemesterRegisteringSeason>
        {
            public int SemesterRegisteringSeasonID {get; set;}
        }

        public class Handler : IRequestHandler<Query, SemesterRegisteringSeason>
        {
            private readonly FacultyDBContext _context;

            public Handler(FacultyDBContext context)
            {
                _context = context;   
            }

            public async Task<SemesterRegisteringSeason> Handle(Query request, CancellationToken cancellationToken)
            {
                var semesterRegisteringSeason = await _context.SemesterRegisteringSeasons.FindAsync(request.SemesterRegisteringSeasonID);

                return semesterRegisteringSeason;
            }
        }

    }
}