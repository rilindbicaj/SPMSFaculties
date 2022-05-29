using System;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Locations
{
    public class Details
    {
        public class Query : IRequest <LocationDto>
        {
            public int LocationID {get; set;}
        }

        public class Handler : IRequestHandler<Query, LocationDto>
        {
             private readonly FacultyDBContext _context;
            private readonly IMapper _mapper;

            public Handler(FacultyDBContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<LocationDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var location = await _context.Locations.FindAsync(request.LocationID);
                var result =_mapper.Map<LocationDto>(location);

                return result;
            }
        }

    }
}