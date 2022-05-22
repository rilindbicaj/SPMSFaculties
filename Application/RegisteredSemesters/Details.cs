using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.RegisteredSemesters
{
    public class Details
    {
        public class Query : IRequest <RegisteredSemester>
        {
            public int RegistrationID {get; set;}
        }

        public class Handler : IRequestHandler<Query, RegisteredSemester>
        {
            private readonly FacultyDBContext _context;

            public Handler(FacultyDBContext context)
            {
                _context = context;   
            }

            public async Task<RegisteredSemester> Handle(Query request, CancellationToken cancellationToken)
            {
                var registeredsemester = await _context.RegisteredSemesters.FindAsync(request.RegistrationID);

                return registeredsemester;
            }
        }

    }
}

