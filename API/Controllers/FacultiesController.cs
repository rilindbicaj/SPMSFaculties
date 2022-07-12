using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Commands.Faculties;
using Application.DTOs;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class FacultiesController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<List<FacultyDto>>> List()
        {
            return await Mediator.Send(new ListFaculties.Query());
        }

        [HttpGet("GetFacultiesForUser/{userId}")]
        public async Task<ActionResult<List<FlatFacultyDTO>>> GetFacultiesForUser(Guid userId)
        {
            return await Mediator.Send(new ListAllFacultiesForUser.Query { UserID = userId });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FlatFacultyDTO>> Details(int id)
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