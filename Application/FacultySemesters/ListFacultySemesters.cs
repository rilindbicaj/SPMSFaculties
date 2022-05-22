using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.FacultySemesters
{
    public class ListFacultySemesters
    {
        public class Query : IRequest<List<FacultySemester>> {}

        public class Handler : IRequestHandler<Query, List<FacultySemester>>
        {
            private readonly FacultyDBContext _context;

            public Handler(FacultyDBContext context)
            {
                _context = context;
            }

            public async Task<List<FacultySemester>> Handle (Query request, CancellationToken cancellationToken)
            {
                var facultysemesters = await _context.FacultySemesters.ToListAsync();

                return facultysemesters;
            }
        }
    }
}