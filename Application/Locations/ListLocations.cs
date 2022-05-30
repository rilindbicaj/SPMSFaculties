using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Locations
{
    public class ListLocations
    {
        public class Query : IRequest<List<LocationDto>> {}

        public class Handler : IRequestHandler<Query, List<LocationDto>>
        {
            private readonly FacultyDBContext _context;
            private readonly IMapper _mapper;

            public Handler(FacultyDBContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<LocationDto>> Handle (Query request, CancellationToken cancellationToken)
            {
                var locations = await _context.Locations.ToListAsync();
                var result =_mapper.Map<List<LocationDto>>(locations);

                return result;
            }
        }
    }
}