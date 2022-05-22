using System.Collections.Generic;
using System.Threading.Tasks;
using Application.RegisteredSemesters;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisteredSemestersController : BaseController
    {
        private readonly IMediator _mediator;

        public RegisteredSemestersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<RegisteredSemester>>> List()
        {
            return await _mediator.Send(new ListRegisteredSemesters.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RegisteredSemester>> Details (int id)
        {
            return await _mediator.Send(new Details.Query{RegistrationID = id});
        }
        
        [HttpPost]
        public async Task<ActionResult<Unit>> Create(Create.Command command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Edit(int id, Edit.Command command)
        {
            command.RegistrationID = id;
            return await _mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(int id)
        {
            return await _mediator.Send(new Delete.Command{RegistrationID = id});
        }
    }
}

