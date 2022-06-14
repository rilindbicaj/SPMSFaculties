using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Responses;
using AutoMapper;
using Domain;
using MediatR;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Persistence;

namespace Application.Queries.BusSchedules
{
    public class GetAllBusSchedules
    {
        public class Query : IRequest<List<BusScheduleResponse>>
        {

        }

        public class Handler : IRequestHandler<Query, List<BusScheduleResponse>>
        {
            private readonly MongoDbContext _context;
            private readonly IMapper _mapper;

            public Handler(MongoDbContext context, IMapper mapper)
            {

                _context = context;
                _mapper = mapper;

            }

            public async Task<List<BusScheduleResponse>> Handle(Query request, CancellationToken token)
            {

                var locations = await _context.Locations.AsQueryable().Where(l => l.BusSchedule != null).ToListAsync();

                return _mapper.Map<List<BusScheduleResponse>>(locations);

            }

        }
    }
}