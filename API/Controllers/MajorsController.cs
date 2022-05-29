using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Majors;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Application.DTOs;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MajorsController : BaseController
    {

        [HttpGet]
        public async Task<ActionResult<List<MajorDto>>> List()
        {
            return await _mediator.Send(new ListMajors.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MajorDto>> Details (int id)
        {
            return await _mediator.Send(new Details.Query{MajorID = id});
        }
        
        [HttpPost]
        public async Task<ActionResult<Unit>> Create(Create.Command command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Edit(int id, Edit.Command command)
        {
            command.Major.MajorID = id;
            return await _mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(int id)
        {
            return await _mediator.Send(new Delete.Command{MajorID = id});
        }
    }
}

