using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Responses;
using AutoMapper;
using Domain;
using MediatR;
using MongoDB.Driver;
using Persistence;

namespace Application.Queries.Locations
{
    public class GetAllLocations
    {
        public class Query : IRequest<List<LocationResponse>>
        {

        }

        public class Handler : IRequestHandler<Query, List<LocationResponse>>
        {
            private readonly MongoDbContext _context;
            private readonly IMapper _mapper;

            public Handler(MongoDbContext context, IMapper mapper)
            {

                _context = context;
                _mapper = mapper;

            }

            public async Task<List<LocationResponse>> Handle(Query request, CancellationToken token)
            {

                var locations = await _context.Locations.AsQueryable().ToListAsync();

                return _mapper.Map<List<LocationResponse>>(locations);

            }

        }
    }
}