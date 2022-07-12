using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs;
using Application.UserFaculties;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class UserFacultiesController : BaseController
    {

        [HttpGet]
        public async Task<ActionResult<List<UserFacultyDto>>> List()
        {
            return await Mediator.Send(new ListUserFaculties.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserFacultyDto>> Details(Guid id)
        {
            return await Mediator.Send(new Details.Query { UserID = id });
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(UserFaculty userFaculty)
        {
            return await Mediator.Send(new Create.Command { UserFaculty = userFaculty });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Edit(Guid id, UserFaculty userFaculty)
        {
            //command.UserFaculty.UserID = id;
            return await Mediator.Send(new Edit.Command { UserFaculty = userFaculty });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(Guid id)
        {
            return await Mediator.Send(new Delete.Command { UserID = id });
        }
    }
}