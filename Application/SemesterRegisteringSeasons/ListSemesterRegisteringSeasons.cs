using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.SemesterRegisteringSeasons
{
    public class ListSemesterRegisteringSeasons
    {
        public class Query : IRequest<List<SemesterRegisteringSeason>> {}

        public class Handler : IRequestHandler<Query, List<SemesterRegisteringSeason>>
        {
            private readonly FacultyDBContext _context;

            public Handler(FacultyDBContext context)
            {
                _context = context;
            }

            public async Task<List<SemesterRegisteringSeason>> Handle (Query request, CancellationToken cancellationToken)
            {
                var semesterRegisteringSeason = await _context.SemesterRegisteringSeasons.ToListAsync();

                return semesterRegisteringSeason;
            }
        }
    }
}