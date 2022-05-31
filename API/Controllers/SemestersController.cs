using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Semesters;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SemestersController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<List<SemesterDto>>> List()
        {
            return await Mediator.Send(new ListSemesters.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SemesterDto>> Details(int id)
        {
            return await Mediator.Send(new Details.Query { SemesterID = id });
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(Semester semester)
        {
            return await Mediator.Send(new Create.Command { Semester = semester });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Edit(int id, Semester semester)
        {
            //command.Semester.SemesterID = id;
            return await Mediator.Send(new Edit.Command { Semester = semester });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(int id)
        {
            return await Mediator.Send(new Delete.Command { SemesterID = id });
        }
    }
}

