using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Faculties;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class FacultiesController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<List<FacultyDto>>> List()
        {
            return await Mediator.Send(new ListFaculties.Query());
        }

        [HttpGet("GetFacultiesForUser/{UserID}")]
        public async Task<ActionResult<List<FlatFacultyDTO>>> GetFacultiesForUser(Guid UserID)
        {
            return await Mediator.Send(new ListFacultiesForUser.Query { UserID = UserID });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FacultyDto>> Details(int id)
        {
            return await Mediator.Send(new Details.Query { FacultyID = id });
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(Faculty faculty)
        {
            return await Mediator.Send(new Create.Command { Faculty = faculty });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Edit(int id, Faculty faculty)
        {
            return await Mediator.Send(new Edit.Command { Faculty = faculty });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(int id)
        {
            return await Mediator.Send(new Delete.Command { FacultyID = id });
        }
    }
}