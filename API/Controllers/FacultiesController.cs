using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using Domain;
using Application.Faculties;
using Microsoft.AspNetCore.Authorization;
using Application.DTOs;

namespace API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]

    public class FacultiesController :  BaseController
    {
        [HttpGet]
        public async Task<ActionResult<List<FacultyDto>>> List()
        {
            return await _mediator.Send(new ListFaculties.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FacultyDto>> Details (int id)
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
            command.Faculty.FacultyID = id;
            return await _mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(int id)
        {
            return await _mediator.Send(new Delete.Command{FacultyID = id});
        }
    }
}