using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Persistence;
using Domain;
using System;
using AutoMapper;

namespace Application.FacultySemesters
{
    public class Create
    {
        public class Command : IRequest
        {
        public FacultySemester FacultySemester { get; set; } 

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
                var facultysemester = await _context.FacultySemesters.FindAsync(request.FacultySemester);

               _mapper.Map(request.FacultySemester, facultysemester);

                _context.FacultySemesters.Add(facultysemester);
                var success = await _context.SaveChangesAsync() > 0;

                if(success) return Unit.Value;

                throw new Exception ("Problem saving changes");
            }
        }
    }
}
