using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.SeasonStatuses
{
    public class ListSeasonStatuses
    {
        public class Query : IRequest<List<SeasonStatusDto>> {}

        public class Handler : IRequestHandler<Query, List<SeasonStatusDto>>
        {
            private readonly FacultyDBContext _context;
            private readonly IMapper _mapper;

            public Handler(FacultyDBContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<SeasonStatusDto>> Handle (Query request, CancellationToken cancellationToken)
            {
                var seasonstatuses = await _context.SeasonStatuses.ToListAsync();

                var result =_mapper.Map<List<SeasonStatusDto>>(seasonstatuses);

                return result;
            }
        }
    }
}

