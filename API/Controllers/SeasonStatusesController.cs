using System.Collections.Generic;
using System.Threading.Tasks;
using Application.SeasonStatuses;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeasonStatusesController : BaseController
    {
        private readonly IMediator _mediator;

        public SeasonStatusesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<SeasonStatus>>> List()
        {
            return await _mediator.Send(new ListSeasonStatuses.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SeasonStatus>> Details (int id)
        {
            return await _mediator.Send(new Details.Query{SeasonStatusID = id});
        }
        
        [HttpPost]
        public async Task<ActionResult<Unit>> Create(Create.Command command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Edit(int id, Edit.Command command)
        {
            command.SeasonStatusID = id;
            return await _mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(int id)
        {
            return await _mediator.Send(new Delete.Command{SeasonStatusID = id});
        }
    }
}

