using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs;
using Application.RegisteredSemesters;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisteredSemestersController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<List<RegisteredSemesterDto>>> List()
        {
            return await Mediator.Send(new ListRegisteredSemesters.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RegisteredSemesterDto>> Details(int id)
        {
            return await Mediator.Send(new Details.Query { RegistrationID = id });
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(RegisteredSemester registeredSemester)
        {
            return await Mediator.Send(new Create.Command { RegisteredSemester = registeredSemester });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Edit(int id, RegisteredSemester registeredSemester)
        {
            //command.RegisteredSemester.RegistrationID = id;
            return await Mediator.Send(new Edit.Command { RegisteredSemester = registeredSemester });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(int id)
        {
            return await Mediator.Send(new Delete.Command { RegistrationID = id });
        }
    }
}

