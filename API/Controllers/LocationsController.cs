using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Queries.Locations;
using Application.Requests;
using Application.Responses;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace API.Controllers
{

    public class LocationsController : BaseController
    {

        [HttpGet]

        public async Task<List<LocationResponse>> GetAllLocations()
        {
            return await Mediator.Send(new GetAllLocations.Query { });
        }

        [HttpGet("withoutSchedule")]

        public async Task<List<LocationResponse>> GetUnassignedLocations()
        {
            return await Mediator.Send(new GetLocationsWithoutSchedule.Query { });
        }

        [HttpGet("{id}")]
        public async Task<LocationResponse> GetLocationById(string id)
        {
            return await Mediator.Send(new GetLocationById.Query { LocationId = ObjectId.Parse(id) });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLocation(string id, LocationUpdateRequest locationUpdateRequest)
        {
            await Mediator.Send(new UpdateLocation.Command { LocationUpdateRequest = locationUpdateRequest, LocationId = ObjectId.Parse(id) });
            return Ok();
        }

    }
}

