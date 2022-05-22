using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Levels;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LevelsController : BaseController
    {
        private readonly IMediator _mediator;

        public LevelsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Level>>> List()
        {
            return await _mediator.Send(new ListLevels.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Level>> Details (int id)
        {
            return await _mediator.Send(new Details.Query{LevelID = id});
        }
        
        [HttpPost]
        public async Task<ActionResult<Unit>> Create(Create.Command command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Edit(int id, Edit.Command command)
        {
            command.LevelID = id;
            return await _mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(int id)
        {
            return await _mediator.Send(new Delete.Command{LevelID = id});
        }
    }
}