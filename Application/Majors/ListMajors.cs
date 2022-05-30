using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Majors
{
    public class ListMajors
    {
        public class Query : IRequest<List<MajorDto>> {}

        public class Handler : IRequestHandler<Query, List<MajorDto>>
        {
            private readonly FacultyDBContext _context;
            private readonly IMapper _mapper;

            public Handler(FacultyDBContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<MajorDto>> Handle (Query request, CancellationToken cancellationToken)
            {
                var majors = await _context.Majors.ToListAsync();
                var result =_mapper.Map<List<MajorDto>>(majors);

                return result;
            }
        }
    }
}

