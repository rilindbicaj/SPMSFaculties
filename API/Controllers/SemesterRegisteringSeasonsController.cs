using System.Collections.Generic;
using System.Threading.Tasks;
using Application.SemesterRegisteringSeasons;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SemesterRegisteringSeasonsController : BaseController
    {
        private readonly IMediator _mediator;

        public SemesterRegisteringSeasonsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<SemesterRegisteringSeason>>> List()
        {
            return await _mediator.Send(new ListSemesterRegisteringSeasons.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SemesterRegisteringSeason>> Details (int id)
        {
            return await _mediator.Send(new Details.Query{SemesterRegisteringSeasonID = id});
        }
        
        [HttpPost]
        public async Task<ActionResult<Unit>> Create(Create.Command command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Edit(int id, Edit.Command command)
        {
            command.SemesterRegisteringSeasonID = id;
            return await _mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(int id)
        {
            return await _mediator.Send(new Delete.Command{SemesterRegisteringSeasonID = id});
        }
    }
}