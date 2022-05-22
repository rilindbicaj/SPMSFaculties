using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using Domain;
using Application.UserFaculties;
using System; 
using Microsoft.AspNetCore.Authorization;


namespace API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]

    public class UserFacultiesController :  ControllerBase
    {
        private readonly IMediator _mediator;

        public UserFacultiesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserFaculty>>> List()
        {
            return await _mediator.Send(new ListUserFaculties.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserFaculty>> Details (Guid id)
        {
            return await _mediator.Send(new Details.Query{UserID = id});
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(Create.Command command)
        {
            return await _mediator.Send(command);
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Edit(Guid id, Edit.Command command)
        {
            command.UserID = id;
            return await _mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(Guid id)
        {
            return await _mediator.Send(new Delete.Command{UserID = id});
        }
    }
}