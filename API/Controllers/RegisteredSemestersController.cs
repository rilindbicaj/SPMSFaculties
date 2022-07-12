using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Queries.Semesters;
using Application.RegisteredSemesters;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

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

        [HttpGet("getRegisteredSemesterInFacultyForStudent/{studentId}/{facultyId}")]
        public async Task<ActionResult<List<SemesterDto>>> GetSemestersForStudentInFaculty(Guid studentId, int facultyId)
        {
            return await Mediator.Send(new GetSemestersForStudentInFaculty.Query
            {
                UserId = studentId,
                FacultyId = facultyId
            });
        }
    }
}

