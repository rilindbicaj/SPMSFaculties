using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Persistence;
using System;
using AutoMapper;

namespace Application.RegisteredSemesters
{
    public class Delete
    {
        public class Command : IRequest
        {
            public int RegistrationID {get; set;}
        }

        public class Handler : IRequestHandler<Command>
        {
           private readonly FacultyDBContext _context;
            private readonly IMapper _mapper;

            public Handler(FacultyDBContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var registeredsemester = await _context.RegisteredSemesters.FindAsync(request.RegistrationID);

                if(registeredsemester == null)
                    throw new Exception("Could not find registeredsemester");

                _context.Remove(registeredsemester);

                var success = await _context.SaveChangesAsync() > 0;

                if(success) return Unit.Value;

                throw new Exception ("Problem saving changes");
            }
        }
    }
}

