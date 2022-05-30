using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Persistence;
using System;
using AutoMapper;
using Application.DTOs;

namespace Application.Faculties
{
    public class Delete
    {
        public class Command : IRequest 
        {
            public int FacultyID {get; set;}
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
                var faculty = await _context.Faculties.FindAsync(request.FacultyID);

                if(faculty == null)
                    throw new Exception("Could not find faculty");

                _context.Remove(faculty);

                var success = await _context.SaveChangesAsync() > 0;

                if(success) return Unit.Value;

                throw new Exception ("Problem saving changes");
            }
        }
    }
}