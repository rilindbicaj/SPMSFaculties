using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Commands.Faculties
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Faculty Faculty { get; set; }
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
                var faculty = await _context.Faculties.FindAsync(request.Faculty.FacultyID);

                if (faculty == null)
                    throw new Exception("Could not find faculty");

                _mapper.Map(request.Faculty, faculty);


                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}