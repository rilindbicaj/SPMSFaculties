using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Persistence;
using System;
using Domain;
using System.Collections.Generic;
using AutoMapper;

namespace Application.SemesterRegisteringSeasons
{
    public class Edit
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
                var semesterRegisteringSeason = await _context.SemesterRegisteringSeasons.FindAsync(request.SemesterRegisteringSeason.SemesterRegisteringSeasonID);

                if(semesterRegisteringSeason == null)
                    throw new Exception ("Could not find SemesterRegisteringSeason");

                 _mapper.Map(request.SemesterRegisteringSeason, semesterRegisteringSeason);
                

                var success = await _context.SaveChangesAsync() > 0;
        
                if(success) return Unit.Value;
        
                throw new Exception ("Problem saving changes");
            }
        }
    }
}