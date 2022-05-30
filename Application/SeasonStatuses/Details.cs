using System;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.SeasonStatuses
{
    public class Details
    {
        public class Query : IRequest <SeasonStatusDto>
        {
            public int SeasonStatusID {get; set;}
        }

        public class Handler : IRequestHandler<Query, SeasonStatusDto>
        {
             private readonly FacultyDBContext _context;
            private readonly IMapper _mapper;

            public Handler(FacultyDBContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<SeasonStatusDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var seasonstatus = await _context.SeasonStatuses.FindAsync(request.SeasonStatusID);

                var result =_mapper.Map<SeasonStatusDto>(seasonstatus);

                return result;
            }
        }

    }
}

