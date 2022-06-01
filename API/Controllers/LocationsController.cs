using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Locations;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : BaseController
    {

        [HttpGet]
        public async Task<ActionResult<List<LocationDto>>> List()
        {
            return await Mediator.Send(new ListLocations.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LocationDto>> Details(int id)
        {
            return await Mediator.Send(new Details.Query { LocationID = id });
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(Location location)
        {
            return await Mediator.Send(new Create.Command { Location = location });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Edit(int id, Location location)
        {
            //command.Location.LocationID = id;
            return await Mediator.Send(new Edit.Command { Location = location });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(int id)
        {
            return await Mediator.Send(new Delete.Command { LocationID = id });
        }
    }
}

