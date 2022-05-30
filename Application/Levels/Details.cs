using System;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Levels
{
    public class Details
    {
        public class Query : IRequest <LevelDto>
        {
            public int LevelID {get; set;}
        }

        public class Handler : IRequestHandler<Query, LevelDto>
        {
            private readonly FacultyDBContext _context;
            private readonly IMapper _mapper;

            public Handler(FacultyDBContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<LevelDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var level = await _context.Levels.FindAsync(request.LevelID);
                var result =_mapper.Map<LevelDto>(level);

                return result;
            }
        }

    }
}