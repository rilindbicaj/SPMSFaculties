using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Persistence;
using Domain;
using System;
using System.Collections.Generic;
using AutoMapper;

namespace Application.UserFaculties
{
    public class Create
    {
        public class Command : IRequest
        {
        public UserFaculty UserFaculty { get; set; }
        
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
               var userfaculty = await _context.UserFaculties.FindAsync(request.UserFaculty);

                 _mapper.Map(request.UserFaculty, userfaculty);

                _context.UserFaculties.Add(userfaculty);
                var success = await _context.SaveChangesAsync() > 0;

                if(success) return Unit.Value;

                throw new Exception ("Problem saving changes");
            }
        }
    }
}


