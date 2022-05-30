using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Persistence;
using Domain;
using System;
using AutoMapper;
using Application.DTOs;

namespace Application.Faculties
{
    public class Create
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
               var faculty = await _context.Faculties.FindAsync(request.Faculty);

               _mapper.Map(request.Faculty, faculty);

                _context.Faculties.Add(faculty);
                var success = await _context.SaveChangesAsync() > 0;

                if(success) return Unit.Value;

                throw new Exception ("Problem saving changes");
            }
        }
    }
}
