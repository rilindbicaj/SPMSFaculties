using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Locations;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Application.DTOs;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : BaseController
    {

        [HttpGet]
        public async Task<ActionResult<List<LocationDto>>> List()
        {
            return await _mediator.Send(new ListLocations.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LocationDto>> Details (int id)
        {
            return await _mediator.Send(new Details.Query{LocationID = id});
        }
        
        [HttpPost]
        public async Task<ActionResult<Unit>> Create(Create.Command command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Edit(int id, Edit.Command command)
        {
            command.Location.LocationID = id;
            return await _mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(int id)
        {
            return await _mediator.Send(new Delete.Command{LocationID = id});
        }
    }
}

