using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Semesters
{
    public class ListSemesters
    {
        public class Query : IRequest<List<SemesterDto>> {}

        public class Handler : IRequestHandler<Query, List<SemesterDto>>
        {
            private readonly FacultyDBContext _context;
            private readonly IMapper _mapper;

            public Handler(FacultyDBContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }


            public async Task<List<SemesterDto>> Handle (Query request, CancellationToken cancellationToken)
            {
                var semesters = await _context.Semesters.ToListAsync();

                var result =_mapper.Map<List<SemesterDto>>(semesters);

                return result;
            }
        }
    }
}

