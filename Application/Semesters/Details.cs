using System;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Semesters
{
    public class Details
    {
        public class Query : IRequest <SemesterDto>
        {
            public int SemesterID {get; set;}
        }

        public class Handler : IRequestHandler<Query, SemesterDto>
        {
            private readonly FacultyDBContext _context;
            private readonly IMapper _mapper;

            public Handler(FacultyDBContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<SemesterDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var semester = await _context.Semesters.FindAsync(request.SemesterID);

                var result =_mapper.Map<SemesterDto>(semester);

                return result;
            }
        }

    }
}

