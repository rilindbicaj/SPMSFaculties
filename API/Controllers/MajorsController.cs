using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Majors;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MajorsController : BaseController
    {

        [HttpGet]
        public async Task<ActionResult<List<MajorDto>>> List()
        {
            return await Mediator.Send(new ListMajors.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MajorDto>> Details(int id)
        {
            return await Mediator.Send(new Details.Query { MajorID = id });
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(Major major)
        {
            return await Mediator.Send(new Create.Command { Major = major });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Edit(int id, Major major)
        {
            //command.Major.MajorID = id;
            return await Mediator.Send(new Edit.Command { Major = major });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(int id)
        {
            return await Mediator.Send(new Delete.Command { MajorID = id });
        }
    }
}

