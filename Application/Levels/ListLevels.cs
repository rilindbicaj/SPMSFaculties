using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Levels
{
    public class ListLevels
    {
        public class Query : IRequest<List<LevelDto>> {}

        public class Handler : IRequestHandler<Query, List<LevelDto>>
        {
              private readonly FacultyDBContext _context;
            private readonly IMapper _mapper;

            public Handler(FacultyDBContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }


            public async Task<List<LevelDto>> Handle (Query request, CancellationToken cancellationToken)
            {
                var levels = await _context.Levels.ToListAsync();
                var result =_mapper.Map<List<LevelDto>>(levels);

                return result;
            }
        }
    }
}