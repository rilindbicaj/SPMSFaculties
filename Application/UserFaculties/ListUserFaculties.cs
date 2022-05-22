using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.UserFaculties
{
    public class ListUserFaculties
    {
        public class Query : IRequest<List<UserFaculty>> {}

        public class Handler : IRequestHandler<Query, List<UserFaculty>>
        {
            private readonly FacultyDBContext _context;

            public Handler(FacultyDBContext context)
            {
                _context = context;
            }

            public async Task<List<UserFaculty>> Handle (Query request, CancellationToken cancellationToken)
            {
                var userfaculties = await _context.UserFaculties.ToListAsync();

                return userfaculties;
            }
        }
    }
}

