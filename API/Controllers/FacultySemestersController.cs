using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs;
using Application.FacultySemesters;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class FacultySemestersController : BaseController
    {

        [HttpGet]
        public async Task<ActionResult<List<FacultySemesterDto>>> List()
        {
            return await Mediator.Send(new ListFacultySemesters.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FacultySemesterDto>> Details(int id)
        {
            return await Mediator.Send(new Details.Query { FacultyID = id });
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(FacultySemester facultySemester)
        {
            return await Mediator.Send(new Create.Command { FacultySemester = facultySemester });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Edit(int id, FacultySemester facultySemester)
        {
            return await Mediator.Send(new Create.Command { FacultySemester = facultySemester });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(int id)
        {
            return await Mediator.Send(new Delete.Command { FacultyID = id });
        }
    }
}