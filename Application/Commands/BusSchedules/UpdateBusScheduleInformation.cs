using System.Threading;
using System.Threading.Tasks;
using Application.Queries.Locations;
using Application.Requests;
using AutoMapper;
using Domain;
using MediatR;
using MongoDB.Bson;
using MongoDB.Driver;
using Persistence;

namespace Application.Queries.BusSchedules
{
    public class UpdateBusScheduleInformation
    {
        public class Command : IRequest
        {
            public BusScheduleInformationUpdateRequest BusScheduleInformationUpdateRequest { get; set; }
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

            public async Task<Unit> Handle(UpdateBusScheduleInformation.Command request, CancellationToken token)
            {

                var modifiedBusSchedule = _mapper.Map<BusSchedule>(request.BusScheduleInformationUpdateRequest);
                
                var updateAction =
                    Builders<Location>.Update.Set(l => l.BusSchedule.DepartingPlace, modifiedBusSchedule.DepartingPlace)
                        .Set(l => l.BusSchedule.DepartingPlaceURL, modifiedBusSchedule.DepartingPlaceURL);

                await _context.Locations.UpdateOneAsync(l => l.LocationId == request.LocationId, updateAction, new UpdateOptions{IsUpsert = true});
                
                return Unit.Value;

            }
        }

    }
}