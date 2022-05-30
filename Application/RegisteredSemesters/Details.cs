using System;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.RegisteredSemesters
{
    public class Details
    {
        public class Query : IRequest <RegisteredSemesterDto>
        {
            public int RegistrationID {get; set;}
        }

        public class Handler : IRequestHandler<Query, RegisteredSemesterDto>
        {
            private readonly FacultyDBContext _context;
            private readonly IMapper _mapper;

            public Handler(FacultyDBContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }


            public async Task<RegisteredSemesterDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var registeredsemester = await _context.RegisteredSemesters.FindAsync(request.RegistrationID);

                var result =_mapper.Map<RegisteredSemesterDto>(registeredsemester);

                return result;
            }
        }

    }
}

