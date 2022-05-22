using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using Domain;
using Application.FacultySemesters;
using Microsoft.AspNetCore.Authorization;


namespace API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]

    public class FacultySemestersController :  ControllerBase
    {
        private readonly IMediator _mediator;

        public FacultySemestersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<FacultySemester>>> List()
        {
            return await _mediator.Send(new ListFacultySemesters.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FacultySemester>> Details (int id)
        {
            return await _mediator.Send(new Details.Query{FacultyID = id});
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(Create.Command command)
        {
            return await _mediator.Send(command);
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Edit(int id, Edit.Command command)
        {
            command.FacultyID = id;
            return await _mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(int id)
        {
            return await _mediator.Send(new Delete.Command{FacultyID = id});
        }
    }
}