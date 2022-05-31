using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.FacultySemesters
{
    public class ListFacultySemesters
    {
        public class Query : IRequest<List<FacultySemesterDto>> { }

        public class Handler : IRequestHandler<Query, List<FacultySemesterDto>>
        {
            private readonly FacultyDBContext _context;
            private readonly IMapper _mapper;

            public Handler(FacultyDBContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<FacultySemesterDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var facultysemesters = await _context.FacultySemesters.ToListAsync();
                var result = _mapper.Map<List<FacultySemesterDto>>(facultysemesters);

                return result;
            }
        }
    }
}