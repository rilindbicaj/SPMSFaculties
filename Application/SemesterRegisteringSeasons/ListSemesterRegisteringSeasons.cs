using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.SemesterRegisteringSeasons
{
    public class ListSemesterRegisteringSeasons
    {
        public class Query : IRequest<List<SemesterRegisteringSeasonDto>> {}

        public class Handler : IRequestHandler<Query, List<SemesterRegisteringSeasonDto>>
        {
            private readonly FacultyDBContext _context;
            private readonly IMapper _mapper;

            public Handler(FacultyDBContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<SemesterRegisteringSeasonDto>> Handle (Query request, CancellationToken cancellationToken)
            {
                var semesterRegisteringSeason = await _context.SemesterRegisteringSeasons.ToListAsync();

                var result =_mapper.Map<List<SemesterRegisteringSeasonDto>>(semesterRegisteringSeason);

                return result;
            }
        }
    }
}