using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Persistence;
using Domain;
using System;
using AutoMapper;

namespace Application.Majors
{
    public class Create
    {
        public class Command : IRequest
        {
        public Major Major { get; set; } 

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
                var major = await _context.Majors.FindAsync(request.Major);

               _mapper.Map(request.Major, major);

                _context.Majors.Add(major);
                var success = await _context.SaveChangesAsync() > 0;

                if(success) return Unit.Value;

                throw new Exception ("Problem saving changes");
            }
        }
    }
}


