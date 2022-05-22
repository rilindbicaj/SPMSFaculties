using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Faculties
{
    public class ListFaculties
    {
        public class Query : IRequest<List<Faculty>> {}

        public class Handler : IRequestHandler<Query, List<Faculty>>
        {
            private readonly FacultyDBContext _context;

            public Handler(FacultyDBContext context)
            {
                _context = context;
            }

            public async Task<List<Faculty>> Handle (Query request, CancellationToken cancellationToken)
            {
                var faculties = await _context.Faculties.ToListAsync();

                return faculties;
            }
        }
    }
}