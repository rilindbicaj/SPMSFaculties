using System.Threading;
using System.Threading.Tasks;
using Application.Responses;
using AutoMapper;
using Domain;
using MediatR;
using MongoDB.Bson;
using MongoDB.Driver;
using Persistence;

namespace Application.Queries.Locations
{
    public class GetLocationById
    {

        public class Query : IRequest<LocationResponse>
        {
            public ObjectId LocationId { get; set; }
        }

        public class Handler : IRequestHandler<Query, LocationResponse>
        {
            private readonly MongoDbContext _context;
            private readonly IMapper _mapper;

            public Handler(MongoDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<LocationResponse> Handle(Query request, CancellationToken token)
            {
                var filter = Builders<Location>.Filter.Eq<ObjectId>(l => l.LocationId, request.LocationId);

                var location = await _context.Locations.FindAsync<Location>(filter);

                var l = await location.SingleOrDefaultAsync();
                
                return _mapper.Map<LocationResponse>(l);
            }
        }

    }
}