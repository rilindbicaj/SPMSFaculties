using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.UserFaculties
{
    public class Details
    {
        public class Query : IRequest <UserFaculty>
        {
            public Guid UserID {get; set;}
        }

        public class Handler : IRequestHandler<Query, UserFaculty>
        {
            private readonly FacultyDBContext _context;

            public Handler(FacultyDBContext context)
            {
                _context = context;   
            }

            public async Task<UserFaculty> Handle(Query request, CancellationToken cancellationToken)
            {
                var userfaculty = await _context.UserFaculties.FindAsync(request.UserID);

                return userfaculty;
            }
        }

    }
}

