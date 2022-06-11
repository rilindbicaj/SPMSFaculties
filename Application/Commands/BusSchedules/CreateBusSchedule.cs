using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Requests;
using Application.Responses;
using AutoMapper;
using Domain;
using MediatR;
using MongoDB.Bson;
using MongoDB.Driver;
using Persistence;

namespace Application.Queries.BusSchedules
{
    public class CreateBusSchedule
    {
        public class Command : IRequest
        {

            public BusScheduleCreateRequest BusScheduleCreateRequest { get; set; }
            public ObjectId LocationId { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly MongoDbContext _context;
            private readonly IMapper _mapper;

            public Handler(MongoDbContext context, IMapper mapper)
            {

                _context = context;
                _mapper = mapper;

            }

            public async Task<Unit> Handle(Command request, CancellationToken token)
            {

                var newBusSchedule = _mapper.Map<BusSchedule>(request.BusScheduleCreateRequest);

                var updateAction = Builders<Location>.Update.Set(l => l.BusSchedule, newBusSchedule);

                await _context.Locations.UpdateOneAsync(l => l.LocationId == request.LocationId, updateAction,
                    new UpdateOptions() { IsUpsert = true });

                return Unit.Value;

            }
        }
    }
}