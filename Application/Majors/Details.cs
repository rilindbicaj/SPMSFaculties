using System;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Majors
{
    public class Details
    {
        public class Query : IRequest <MajorDto>
        {
            public int MajorID {get; set;}
        }

        public class Handler : IRequestHandler<Query, MajorDto>
        {
            private readonly FacultyDBContext _context;
            private readonly IMapper _mapper;

            public Handler(FacultyDBContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<MajorDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var major = await _context.Majors.FindAsync(request.MajorID);
                var result =_mapper.Map<MajorDto>(major);

                return result;
            }
        }

    }
}

