using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.FacultySemesters
{
    public class Details
    {
        public class Query : IRequest <FacultySemester>
        {
            public int FacultyID {get; set;}
        }

        public class Handler : IRequestHandler<Query, FacultySemester>
        {
            private readonly FacultyDBContext _context;

            public Handler(FacultyDBContext context)
            {
                _context = context;   
            }

            public async Task<FacultySemester> Handle(Query request, CancellationToken cancellationToken)
            {
                var facultysemester = await _context.FacultySemesters.FindAsync(request.FacultyID);

                return facultysemester;
            }
        }

    }
}