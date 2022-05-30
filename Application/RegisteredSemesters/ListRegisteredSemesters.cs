using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.RegisteredSemesters
{
    public class ListRegisteredSemesters
    {
        public class Query : IRequest<List<RegisteredSemesterDto>> {}

        public class Handler : IRequestHandler<Query, List<RegisteredSemesterDto>>
        {
            private readonly FacultyDBContext _context;
            private readonly IMapper _mapper;

            public Handler(FacultyDBContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<RegisteredSemesterDto>> Handle (Query request, CancellationToken cancellationToken)
            {
                var registeredsemesters = await _context.RegisteredSemesters.ToListAsync();

                var result =_mapper.Map<List<RegisteredSemesterDto>>(registeredsemesters);

                return result;
            }
        }
    }
}

