using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Persistence;
using Domain;
using System;
using System.Collections.Generic;
using AutoMapper;

namespace Application.SemesterRegisteringSeasons
{
    public class Create
    {
        public class Command : IRequest
        {
        public SemesterRegisteringSeason SemesterRegisteringSeason { get; set; }

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
                var semesterRegisteringSeason = await _context.SemesterRegisteringSeasons.FindAsync(request.SemesterRegisteringSeason);

               _mapper.Map(request.SemesterRegisteringSeason, semesterRegisteringSeason);

                _context.SemesterRegisteringSeasons.Add(semesterRegisteringSeason);
                var success = await _context.SaveChangesAsync() > 0;

                if(success) return Unit.Value;

                throw new Exception ("Problem saving changes");
            }
        }
    }
}
