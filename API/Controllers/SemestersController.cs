using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Semesters;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Application.DTOs;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SemestersController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<List<SemesterDto>>> List()
        {
            return await _mediator.Send(new ListSemesters.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SemesterDto>> Details (int id)
        {
            return await _mediator.Send(new Details.Query{SemesterID = id});
        }
        
        [HttpPost]
        public async Task<ActionResult<Unit>> Create(Create.Command command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Edit(int id, Edit.Command command)
        {
            command.Semester.SemesterID = id;
            return await _mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(int id)
        {
            return await _mediator.Send(new Delete.Command{SemesterID = id});
        }
    }
}

